using FlaxEngine;
using FlaxEngine.GUI;

namespace Pawtools;

public class InteractionRaycaster : Script
{
    public float MaxDistance = 500f;
    
    private Label _interactLabel;
    private Actor _interactContainer;

    public override void OnStart()
    {
        // 1. Find the top-level Canvas
        var canvas = Scene.FindActor("UICanvas");
        if (canvas != null)
        {
            // 2. Find the 'Interact' container Actor
            _interactContainer = canvas.GetChild("Interact");
            if (_interactContainer != null)
            {
                // 3. Find the 'Label' Actor
                var labelActor = _interactContainer.GetChild("Label");
                if (labelActor != null)
                {
                    // 4. In Flax, UI elements live inside a UIControl script
                    var uiControl = labelActor as UIControl;
                    if (uiControl != null)
                    {
                        _interactLabel = uiControl.Control as Label;
                    }
                }
            }
        }
        
        // Hide UI by default
        if (_interactContainer != null) _interactContainer.IsActive = false;
    }

    public override void OnUpdate()
    {
        Ray ray = Camera.MainCamera.ConvertMouseToRay(Screen.Size * 0.5f);
        bool hitInteractable = false;

        if (Physics.RayCast(ray.Position, ray.Direction, out RayCastHit hit, MaxDistance))
        {
            var interactable = hit.Collider.GetScript<Interactable>();
            
            if (interactable != null)
            {
                hitInteractable = true;
                UpdateUI(interactable);

                if (Input.GetKeyDown(interactable.InteractionKey))
                {
                    interactable.OnInteract();
                }
            }
        }

        // Toggle UI visibility based on hit status
        if (_interactContainer != null && _interactContainer.IsActive != hitInteractable)
            _interactContainer.IsActive = hitInteractable;
    }

    private void UpdateUI(Interactable interactable)
    {
        if (_interactLabel != null)
        {
            _interactLabel.Text = $"Press {interactable.InteractionKey} to {interactable.InteractionSuffix}";
        }
    }
}
