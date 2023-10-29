using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPos;

    [SerializeField] private List<GameObject> enemyTypes;

    [SerializeField] private float timeBetweenEnemy;
    [SerializeField] private float timeReducage;
    [SerializeField] private float minTime;

    private bool canSpawn = true;

    private void Update()
    {
        if (canSpawn)
        {
            Invoke(nameof(Spawn), timeBetweenEnemy);
            canSpawn = false;
        }
        
    }

    private void Spawn()
    {
        Instantiate(enemyTypes[Random.Range(0,enemyTypes.Count-1)], spawnPos[Random.Range(0, spawnPos.Count)].position, Quaternion.identity);
        if (timeBetweenEnemy > minTime)
        {
            if (timeBetweenEnemy > 25f)
            {
                timeBetweenEnemy = 20f;
            }else timeBetweenEnemy -= timeReducage;
        }
        
        canSpawn = true;
    }
}
