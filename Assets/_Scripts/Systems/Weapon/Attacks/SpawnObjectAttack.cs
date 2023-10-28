
using Unity.Mathematics;
using UnityEngine;

public class SpawnObjectAttack : Attack
{
    public GameObject prefab;
    public override void Perform(Transform player, Vector2 clickPos)
    {
        Instantiate(prefab, clickPos, Quaternion.identity);
    }
}
