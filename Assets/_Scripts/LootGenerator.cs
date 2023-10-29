using UnityEngine;

public class LootGenerator : MonoBehaviour
{
    public int resources;

    [SerializeField] private GameObject generatingItem;
    [SerializeField] private int resourcePerTime;
    [SerializeField] private float timeForResource;

    private bool canAdd = true;
    private GameObject spawnedItem;
    [SerializeField] private Transform spawnPos;

    private void Update()
    {
        if (canAdd)
        {
            canAdd = false;
            Invoke(nameof(AddItem), timeForResource);
        }
    }

    private void AddItem()
    {
        if (spawnedItem != null) Destroy(spawnedItem);
        resources += resourcePerTime;
        canAdd = true;

        spawnedItem = Instantiate(generatingItem, spawnPos.position, Quaternion.identity);
        spawnedItem.GetComponent<ItemDrop>().amount = resources;
    }
}
