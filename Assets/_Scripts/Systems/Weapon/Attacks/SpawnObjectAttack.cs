
using UnityEngine;

public class SpawnObjectAttack : Attack
{
    public override void Perform()
    {
        Instantiate((data as SpawnObjectAttackData).prefab, transform.position, Quaternion.identity);
    }
}
