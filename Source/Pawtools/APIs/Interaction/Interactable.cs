using FlaxEngine;

namespace Pawtools;

/// <summary>
/// Interactable
/// </summary>
public class Interactable : Script
{   
    /// <summary>
    /// The key required to interact with this specific object.
    /// </summary>
    public KeyboardKeys InteractionKey = KeyboardKeys.E;

    /// <summary>
    /// Suffix string so each object can describe its action.
    /// </summary>
    public string InteractionSuffix = "Interact";

    /// <summary>
    /// Called when this interactable is interacted with
    /// </summary>
    public virtual void OnInteract()
    {
        
    }
}