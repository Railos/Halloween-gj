using UnityEngine;

public abstract class IInteractable : MonoBehaviour
{
    public bool usePrimaryButton, useSecondaryButton;
    public string hoverMessage;
    public abstract void Interact();
}
