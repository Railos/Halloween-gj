 using System;
using UnityEngine;

public class Upgradable : IInteractable
{
    [SerializeField] private int maxLevel;
    public int level;

    public float upgradeCost;

    [SerializeField] private float upgradeCostCoefficient;

    public GameObject[] sprites;

    private void Start()
    {
        
    }

    public override void Interact()
    {
        Upgrade();
    }

    public void Upgrade()
    {
        sprites[level].SetActive(false);
        level++;
        sprites[level].SetActive(true);
        
        upgradeCost *= upgradeCostCoefficient;
        
        if (level == maxLevel) gameObject.SetActive(false);
    }
}
