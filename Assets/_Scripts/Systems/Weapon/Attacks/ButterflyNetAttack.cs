
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public class ButterflyNetAttack : Attack
{
    public float catchRadius;
    public bool catched;
    public Grave graveDestination;
    public override void Perform(Transform player, Vector2 clickPos)
    {
        Collider2D[] result = Physics2D.OverlapCircleAll(player.position, catchRadius);
        if (catched)
        {
            Grave grave;
            Collider2D res = result.FirstOrDefault(c => c.gameObject.TryGetComponent(out grave) && c.gameObject.GetComponent<Grave>() == graveDestination && !c.gameObject.GetComponent<Grave>().hasSoul);
            if (res != null)
            {
                player.GetComponent<PlayerBootstrap>().soulCatchedLight.SetActive(false);
                res.GetComponent<Grave>().ReturnSoul();
                catched = false;
                graveDestination = null;
            }
        }
        else
        {
            SoulUnit ghost = null;
            result.FirstOrDefault(c => c.gameObject.TryGetComponent(out ghost));
            
            if (ghost)
            {
                Destroy(ghost.gameObject);
                player.GetComponent<PlayerBootstrap>().soulCatchedLight.SetActive(true);
                ghost.linkedGrave.Highlight();
                catched = true;
                graveDestination = ghost.linkedGrave;
            }
        }
    }
}
