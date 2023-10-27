using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    public InventorySystem inventory;
    public Weapon equippedWeapon; // Выбранное оружие


    private void Start()
    {
        equippedWeapon = inventory.inventory.Where(stack => stack.item is Weapon).ToList()[0].item as Weapon;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Проверка на нажатие ЛКМ
        {
            PerformAttack();
        }

        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
        {
            List<ItemStack> stacks = inventory.inventory.Where(stack => stack.item is Weapon).ToList();
            int index = stacks.FindIndex(a => a.item == equippedWeapon);
            equippedWeapon = stacks[index + 1 < stacks.Count ? index + 1 : 0].item as Weapon;
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
        {
            List<ItemStack> stacks = inventory.inventory.Where(stack => stack.item is Weapon).ToList();
            int index = stacks.FindIndex(a => a.item == equippedWeapon);
            equippedWeapon = stacks[index - 1 >= 0 ? index - 1 : stacks.Count-1].item as Weapon;
        }
    }

    private void PerformAttack()
    {
        if (equippedWeapon != null)
        {
            AttackData attackData = equippedWeapon.attackData;
            if (attackData != null)
            {
                // Получаем позицию мыши в мировых координатах
                Vector2 clickPosition = GetMouseWorldPosition();
                
                // Создаем атаку в точке клика
                Attack newAttack = Instantiate(attackData.attackPrefab, clickPosition, Quaternion.identity).GetComponent<Attack>();

                // Выполняем атаку
                newAttack.Perform();
            }
        }
    }

    private Vector2 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}