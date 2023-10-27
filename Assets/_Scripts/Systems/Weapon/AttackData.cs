using UnityEngine;

//[CreateAssetMenu(fileName = "New Attack Data", menuName = "Inventory/Attack Data")]
public abstract class AttackData : ScriptableObject
{
    public GameObject attackPrefab;
}