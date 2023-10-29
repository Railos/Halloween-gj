using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectileAttack : Attack
{
    public GameObject projectilePrefab;
    public float cooldown = 0.5f; // Время кулдауна между атаками
    private float lastAttackTime;

    // Start is called before the first frame update
    void Start()
    {
        lastAttackTime = -cooldown; // Устанавливаем время в прошлое, чтобы сразу можно было атаковать
    }

    // Update is called once per frame
    void Update()
    {
        // Дополнительная логика атаки, если необходимо
    }

    public override void Perform(Transform player, Vector2 clickPos)
    {
        if (Time.time - lastAttackTime >= cooldown)
        {
            Vector3 dir = clickPos - (Vector2)player.position;
            Vector3 myLocation = player.position;
            Vector3 targetLocation = clickPos;
            targetLocation.z = myLocation.z; // ensure there is no 3D rotation by aligning Z position

            // vector from this object towards the target location
            Vector3 vectorToTarget = targetLocation - myLocation;
            // rotate that vector by 90 degrees around the Z axis
            Vector3 rotatedVectorToTarget = Quaternion.Euler(0, 0, 90) * vectorToTarget;

            // get the rotation that points the Z axis forward, and the Y axis 90 degrees away from the target
            // (resulting in the X axis facing the target)
            Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorToTarget);

            Instantiate(projectilePrefab, player.GetComponent<PlayerBootstrap>().shootPoint.position, targetRotation);
            
            lastAttackTime = Time.time; // Запоминаем время последней атаки
        }
    }
}