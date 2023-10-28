using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftButtonPrefab : MonoBehaviour
{
    public Image icon;
    public TMP_Text name;
    public TMP_Text amount;
    public Craft craft;

    public void Clicked()
    {
        CraftMenu.craftMenu.ChooseRecipe(GetComponent<Button>());
    }
}
