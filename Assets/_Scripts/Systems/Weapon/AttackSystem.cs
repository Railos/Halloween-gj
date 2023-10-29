using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AttackSystem : Singleton<AttackSystem>
{
    public RectTransform itemPanel;
    public TextMeshProUGUI currentItemText;
    public Image currentItemIcon;
    public Transform player;
    public Transform attacksHolder;
    public int equippedWeaponIndex; // Выбранное оружие
    public List<Weapon> weapons = new List<Weapon>();
    public Dictionary<Weapon, Attack> attacks = new Dictionary<Weapon, Attack>();
    public float weaponSwitchCooldown = 1.0f; // Время кулдауна на переключение оружия
    private float lastSwitchTime;

    private void Start()
    {
        equippedWeaponIndex = 0;
        foreach (var w in weapons)
        {
            attacks.Add(w, Instantiate(w.attackPrefab, attacksHolder).GetComponent<Attack>());
        }

        UpdateUI();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Проверка на нажатие ЛКМ
        {
            PerformAttack();
        }

        if (Time.time - lastSwitchTime >= weaponSwitchCooldown)
        {
            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
            {
                SwitchToNextWeapon();
            }
            else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
            {
                SwitchToPreviousWeapon();
            }
        }
    }

    private void SwitchToNextWeapon()
    {
        equippedWeaponIndex = (equippedWeaponIndex + 1) % weapons.Count;
        lastSwitchTime = Time.time;
        UpdateUI();
    }

    private void SwitchToPreviousWeapon()
    {
        equippedWeaponIndex = (equippedWeaponIndex - 1 + weapons.Count) % weapons.Count;
        lastSwitchTime = Time.time;
        UpdateUI();
    }

    private void PerformAttack()
    {
        if (attacks.TryGetValue(weapons[equippedWeaponIndex], out var attack))
        {
            attack.Perform(player, GetMouseWorldPosition());
        }
    }

    private Vector2 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private void UpdateUI()
    {
        currentItemText.text = weapons[equippedWeaponIndex].itemName;
        currentItemIcon.sprite = weapons[equippedWeaponIndex].itemImage;
    }

    public void AddWeapon(Weapon weapon)
    {
        weapons.Add(weapon);
        attacks[weapon] = Instantiate(weapon.attackPrefab, attacksHolder).GetComponent<Attack>();
    }
}
