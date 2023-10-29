using UnityEngine;
using UnityEngine.Events;

public class Grave : IInteractable
{
    public UnityEvent OnHighlight, OnRemoveHighlight;
    public bool hasSoul = true; // Изначально гробница должна иметь душу
    public GameObject soulPrefab;
    public float minCleanSpawnInterval = 5.0f; // Минимальное время между спавном душ из чистой могилы
    public float maxCleanSpawnInterval = 15.0f; // Максимальное время между спавном душ из чистой могилы
    public float minDirtySpawnInterval = 2.0f; // Минимальное время между спавном душ из грязной могилы
    public float maxDirtySpawnInterval = 8.0f; // Максимальное время между спавном душ из грязной могилы
    public float cleanFactorDuration = 20.0f; // Время, после которого фактор чистоты становится false
    private float lastSpawnTime;
    private float lastInteractTime;
    private bool isClean = true;
    public float currentSpawnInterval;
    private void Start()
    {
        lastSpawnTime = Time.time;
        lastInteractTime = Time.time;
        currentSpawnInterval = isClean ? Random.Range(minCleanSpawnInterval, maxCleanSpawnInterval) : Random.Range(minDirtySpawnInterval, maxDirtySpawnInterval);
    }

    private void Update()
    {
        if (hasSoul && Time.time - lastSpawnTime >= currentSpawnInterval)
        {
            SpawnSoul();
        }

        if (isClean && Time.time - lastInteractTime >= cleanFactorDuration)
        {
            isClean = false;
            currentSpawnInterval = isClean ? Random.Range(minCleanSpawnInterval, maxCleanSpawnInterval) : Random.Range(minDirtySpawnInterval, maxDirtySpawnInterval);
        }
    }

    public override void Interact()
    {
        lastSpawnTime = Time.time;
        lastInteractTime = Time.time;
        isClean = true;
    }

    private void SpawnSoul()
    {
        SoulUnit u = Instantiate(soulPrefab, transform.position, Quaternion.identity).GetComponent<SoulUnit>();
        hasSoul = false;
        u.linkedGrave = this;
        hasSoul = false;
        lastSpawnTime = Time.time;
        currentSpawnInterval = isClean ? Random.Range(minCleanSpawnInterval, maxCleanSpawnInterval) : Random.Range(minDirtySpawnInterval, maxDirtySpawnInterval);

    }
    
    public void ReturnSoul()
    {
        RemoveHighlight();
        lastSpawnTime = Time.time;
        hasSoul = true;
        currentSpawnInterval = isClean ? Random.Range(minCleanSpawnInterval, maxCleanSpawnInterval) : Random.Range(minDirtySpawnInterval, maxDirtySpawnInterval);
    }

    public void Highlight()
    {
        OnHighlight.Invoke();
    }

    public void RemoveHighlight()
    {
        OnRemoveHighlight.Invoke();
    }
}
