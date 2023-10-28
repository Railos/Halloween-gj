using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftSystem : MonoBehaviour
{
    public static CraftSystem crafting;

    private void Awake()
    {
        if (crafting != null)
        {
            Destroy(crafting);
        }
        else
        {
            crafting = this;
        }
    }

    public void Craft(Craft craft)
    {
        var inventory = InventorySystem.Inventory;
        //Проверяем на наличие нужных ресурсов
        foreach (ItemStack itemStack in craft.resources)
        {
            ItemStack existingStack = InventorySystem.Inventory.inventory.Find(stack => stack.item == itemStack.item);
            if (existingStack != null)
            {
                if (existingStack.amount >= itemStack.amount)
                {
                    Debug.Log("Ингридиент есть!");
                }
                else
                {
                    Debug.Log($"Не хватает {itemStack.amount - existingStack.amount} {existingStack.item.itemName}");
                    return;
                }
            }
        }

        foreach (var curStack in craft.result)
        {
            ItemStack newStack = new ItemStack
            {
                item = curStack.item,
                amount = curStack.amount
            };
            inventory.inventory.Add(newStack);
            var newItem = Instantiate(inventory.itemToInstantiate, Vector3.zero, Quaternion.identity, inventory.itemGrid).GetComponent<ItemPrefab>();
            
            newItem.image.sprite = newStack.item.itemImage;
            newItem.amountText.text = newStack.amount.ToString();
        }
        
    }
}
