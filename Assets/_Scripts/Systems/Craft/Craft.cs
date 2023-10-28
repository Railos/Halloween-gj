using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Craft", menuName = "Craft")]
public class Craft : ScriptableObject
{
    public List<ItemStack> resources;
    public List<ItemStack> result;
}
