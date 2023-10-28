using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InteractEvent : UnityEvent {}

public class SimpleInteractable : IInteractable
{
    
    public InteractEvent Event;
    
    public override void Interact()
    {
        Event.Invoke();
    }
}
