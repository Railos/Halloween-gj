using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public List<ItemStack> inventory = new();

    // Добавление предмета в инвентарь
    public void AddItem(Item item, int amount)
    {
        ItemStack existingStack = inventory.Find(stack => stack.item == item);

        if (existingStack != null)
        {
            existingStack.amount += amount;
        }
        else
        {
            ItemStack newStack = new ItemStack
            {
                item = item,
                amount = amount
            };
            inventory.Add(newStack);
        }
    }

    // Удаление предмета из инвентаря
    public bool RemoveItem(Item item, int amount)
    {
        ItemStack existingStack = inventory.Find(stack => stack.item == item);

        if (existingStack != null)
        {
            existingStack.amount -= amount;

            if (existingStack.amount <= 0)
            {
                inventory.Remove(existingStack);
            }

            return true;
        } 
        return false;
    }
}
