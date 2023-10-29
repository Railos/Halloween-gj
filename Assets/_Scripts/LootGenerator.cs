using UnityEngine;

public class LootGenerator : MonoBehaviour
{
    public float resources;

    [SerializeField] private Item generatingItem;
    [SerializeField] private float resourcePerTime;
    [SerializeField] private float timeForResource;

    private bool canAdd = true;

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
        resources += resourcePerTime;
        canAdd = true;
    }
}
