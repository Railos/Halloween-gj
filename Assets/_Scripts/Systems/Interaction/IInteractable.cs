using UnityEngine;

public abstract class IInteractable : MonoBehaviour
{
    public KeyCode interactButton;
    public float interactTime;
    public string hoverMessage;
    public abstract void Interact();
}
