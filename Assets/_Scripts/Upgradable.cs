 using System;
 using System.Collections.Generic;
 using DG.Tweening;
 using TMPro;
 using UnityEngine;

public class Upgradable : MonoBehaviour
{
    public IInteractable Interactable;
    [SerializeField] private int maxLevel;
    public int level;

    public List<ItemStack> upgradeCost;

    [SerializeField] private int upgradeCostCoefficient;

    [SerializeField] private GameObject hoverTooltip;
    [SerializeField] private TMP_Text hoverText;

    public GameObject[] sprites;

    private void Start()
    {
        
    }

    private void Update()
    {
        
        foreach (var itemStack in upgradeCost)
        {
            ItemStack existingStack = InventorySystem.Inventory.inventory.Find(stack => stack.item == itemStack.item);

            if (existingStack != null)
            {
                if (existingStack.amount < itemStack.amount)
                {
                    hoverText.text = "Недостаточно ресурсов!";
                    Interactable.enabled = false;
                    return;
                }
            }
            else
            {
                Interactable.enabled = false;
                return;
            }
        }
        Interactable.enabled = true;

        
    }

    public void Upgrade()
    {
        foreach (var itemStack in upgradeCost)
        {
            ItemStack existingStack = InventorySystem.Inventory.inventory.Find(stack => stack.item == itemStack.item);

            if (existingStack != null)
            {
                if (existingStack.amount < itemStack.amount)
                {
                    hoverText.text = "Недостаточно ресурсов!";
                    return;
                }
            }
            else
            {
                return;
            }
        }
        
        foreach (var itemStack in upgradeCost)
        {
            itemStack.amount *= upgradeCostCoefficient;
        }
        
        sprites[level].SetActive(false);
        level++;
        sprites[level].SetActive(true);
        
        if (level == maxLevel)
        {
            Destroy(GetComponent<SimpleInteractable>());
            
            hoverTooltip.GetComponent<CanvasGroup>().DOFade(0f, 0.3f).SetEase(Ease.InOutCubic);
        }
    }
}
