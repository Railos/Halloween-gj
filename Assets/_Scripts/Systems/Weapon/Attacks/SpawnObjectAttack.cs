
using Unity.Mathematics;
using UnityEngine;

public class SpawnObjectAttack : Attack
{
    public AudioClip shootSound;
    public float cooldown = 0.5f; // Время кулдауна между атаками
    private float lastAttackTime;
    public GameObject prefab;
    
    void Start()
    {
        lastAttackTime = -cooldown; // Устанавливаем время в прошлое, чтобы сразу можно было атаковать
    }
    
    public override void Perform(Transform player, Vector2 clickPos)
    {
        if (Time.time - lastAttackTime >= cooldown)
        {
            Instantiate(prefab, clickPos, Quaternion.identity);

            lastAttackTime = Time.time; // Запоминаем время последней атаки
            AudioSystem.Instance.PlaySound(shootSound);

        }
    }
}
