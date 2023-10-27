
using UnityEngine;

public class SpawnObjectAttack : Attack
{
    public SpawnObjectAttackData data;
    public override void Perform()
    {
        Instantiate(data.prefab, transform.position, Quaternion.identity);
    }
}
