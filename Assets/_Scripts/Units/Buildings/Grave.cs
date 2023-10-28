using UnityEngine;

public class Grave : IInteractable
{
    public bool hasSoul;
    public GameObject soulPrefab;
    
    public override void Interact()
    {
        SoulUnit u = Instantiate(soulPrefab, transform.position, Quaternion.identity).GetComponent<SoulUnit>();
        hasSoul = false;
        u.linkedGrave = this;
    }

    public void ReturnSoul()
    {
        hasSoul = true;
    }
}
