using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftSystem : MonoBehaviour
{
    public static CraftSystem crafting;
    public AudioClip craftSound;
    public List<Craft> crafts;

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

    public void OpenMenu()
    {
        CraftMenu.craftMenu.OpenMenu();
    }
    
    public void Craft(Craft craft)
    {
        var inventory = InventorySystem.Inventory;
        //Проверяем на наличие нужных ресурсов

        if (!CanCraft(craft))
        {
            return;
        }
        foreach (var z in craft.resources)
        {
            inventory.RemoveItem(z.item, z.amount);
        }

        foreach (var curStack in craft.result)
        {
            ItemStack newStack = new ItemStack
            {
                item = curStack.item,
                amount = curStack.amount
            };
            inventory.AddItem(newStack.item, newStack.amount);
            
        }
        AudioSystem.Instance.PlaySound(craftSound);
    }

    public bool CanCraft(Craft craft)
    {
        foreach (ItemStack itemStack in craft.resources)
        {
            ItemStack existingStack = InventorySystem.Inventory.inventory.Find(stack => stack.item == itemStack.item);
            if (existingStack != null)
            {
                if (existingStack.amount >= itemStack.amount)
                {
                    
                }
                else
                {
                    return false;
                }
            }
            else return false;
        }

        return true;
    }
}
