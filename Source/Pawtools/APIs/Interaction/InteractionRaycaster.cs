using FlaxEngine;

namespace Pawtools;

/// <summary>
/// The raycaster for interactions
/// </summary>
public class InteractionRaycaster : Script
{
    /// <summary>
    /// The max distance in units
    /// </summary>
    public float MaxDistance = 500f;

    /// <inheritdoc/>
    public override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyboardKeys.E))
        {
            PerformRaycast();
        }
    }

    private void PerformRaycast()
    {
        // 1. Convert mouse position to a 3D ray from the camera
        Ray ray = Camera.MainCamera.ConvertMouseToRay(new Float2(Screen.Size.X / 2, Screen.Size.Y / 2));

        // 3. Cast the ray with the mask
        if (Physics.RayCast(ray.Position, ray.Direction, out RayCastHit hit, MaxDistance))
        {
            // Draw a GREEN line to the hit point for 2 seconds
            DebugDraw.DrawLine(ray.Position, hit.Point, Color.Green, 2f);

            var interactable = hit.Collider.GetScript<Interactable>();
            if (interactable != null)
            {
                interactable.OnInteract();
            }
        }
        else
        {
            // Draw a RED line representing the full miss distance for 2 seconds
            DebugDraw.DrawLine(ray.Position, ray.Position + ray.Direction * MaxDistance, Color.Red, 2f);
        }
    }
}
