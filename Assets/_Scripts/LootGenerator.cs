using UnityEngine;

public class LootGenerator : MonoBehaviour
{
    public float resources;
    
    [SerializeField] private float resourcePerTime;
    [SerializeField] private float timeForResource;

    public bool canInteract;
    
    private bool canAdd = true;

    private void Update()
    {
        if (canAdd)
        {
            canAdd = false;
            Invoke(nameof(AddMoney), timeForResource);
        }

        if (!canInteract) return;
        if (Input.GetKeyDown(KeyCode.E)) Interact();
    }

    private void Interact()
    {
        Debug.Log($"Collected {resources} resources.");
        resources = 0;
    }

    private void AddMoney()
    {
        resources += resourcePerTime;
        canAdd = true;
    }
}
