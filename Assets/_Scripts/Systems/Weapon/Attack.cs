using UnityEngine;

public class Attack : MonoBehaviour
{
    public AttackData data;
    public Transform player;

    public virtual void Perform() { }
}