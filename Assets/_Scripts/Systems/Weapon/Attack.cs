using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    public abstract void Perform(Transform player, Vector2 clickPos);
}