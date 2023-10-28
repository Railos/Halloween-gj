using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    public Transform player;
    public Transform attacksHolder;
    public int equippedWeaponIndex; // Выбранное оружие
    public List<Weapon> weapons = new();
    public Dictionary<Weapon, Attack> attacks = new();

    private void Start()
    {
        equippedWeaponIndex = 0;
        foreach (var w in weapons)
        {
            attacks.Add(w, Instantiate(w.attackPrefab, attacksHolder).GetComponent<Attack>());
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Проверка на нажатие ЛКМ
        {
            PerformAttack();
        }

        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
        {
            equippedWeaponIndex = equippedWeaponIndex + 1 < weapons.Count ? equippedWeaponIndex + 1: 0;
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
        {
            equippedWeaponIndex = equippedWeaponIndex - 1 < -1 ? equippedWeaponIndex - 1: weapons.Count - 1;
        }
    }

    private void PerformAttack()
    {
        attacks[weapons[equippedWeaponIndex]].Perform(player, GetMouseWorldPosition());
    }

    private Vector2 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    public void AddWeapon(Weapon weapon)
    {
        weapons.Add(weapon);
        attacks[weapon] = Instantiate(weapon.attackPrefab, attacksHolder).GetComponent<Attack>();
    }
}