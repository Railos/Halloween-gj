using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Inventory;
    
    public GameObject itemToInstantiate;
    public Transform itemGrid;
    public GameObject inventoryCanvas;

    public List<ItemStack> inventory = new();

    // Добавление предмета в инвентарь

    private void Awake()
    {
        if (Inventory != null)
        {
            Destroy(Inventory);
        }
        else
        {
            Inventory = this;
        }
    }
    
    private void Start()
    {
        inventoryCanvas.SetActive(false);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryCanvas.SetActive(!inventoryCanvas.activeSelf);
        }

        inventoryCanvas.transform.position = new Vector3(PlayerMove.player.transform.position.x, PlayerMove.player.transform.position.y + 2.5f, 0f);
    }

    public void AddItem(Item item, int amount)
    {
        ItemStack existingStack = inventory.Find(stack => stack.item == item);

        if (existingStack != null)
        {
            existingStack.amount += amount;
            int index = inventory.IndexOf(existingStack);

            var itemStack = itemGrid.GetChild(index).GetComponent<ItemPrefab>();
            itemStack.amountText.text = existingStack.amount.ToString();
        }
        else
        {
            ItemStack newStack = new ItemStack
            {
                item = item,
                amount = amount
            };
            inventory.Add(newStack);
            var newItem = Instantiate(itemToInstantiate, Vector3.zero, Quaternion.identity, itemGrid).GetComponent<ItemPrefab>();
            
            newItem.image.sprite = newStack.item.itemImage;
            newItem.amountText.text = newStack.amount.ToString();
        }
        
        ReRender();
    }

    // Удаление предмета из инвентаря
    public void RemoveItem(Item item, int amount)
    {
        ItemStack existingStack = inventory.Find(stack => stack.item == item);

        if (existingStack != null)
        {
            existingStack.amount -= amount;

            int index = inventory.IndexOf(existingStack);

            var itemStack = itemGrid.GetChild(index).GetComponent<ItemPrefab>();
            itemStack.amountText.text = existingStack.amount.ToString();
            
            if (existingStack.amount <= 0)
            {
                inventory.Remove(existingStack);
                
                Destroy(itemStack.gameObject);
            }
        }
        
        ReRender();
    }

    public void ReRender()
    {
        foreach (Transform child in itemGrid.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var z in inventory)
        {
            var newItem = Instantiate(itemToInstantiate, Vector3.zero, Quaternion.identity, itemGrid).GetComponent<ItemPrefab>();
            
            newItem.image.sprite = z.item.itemImage;
            newItem.amountText.text = z.amount.ToString();
        }
    }
}
