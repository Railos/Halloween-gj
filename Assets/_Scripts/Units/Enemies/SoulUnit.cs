using System;
using Pathfinding;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoulUnit : AIPath
{
    public Grave linkedGrave;

    private void Start()
    {
        GetComponent<AIDestinationSetter>().target =
            LevelBootstrap.Instance.exitPoints[Random.Range(0, LevelBootstrap.Instance.exitPoints.Count)];
        
    }

    public override void OnTargetReached()
    {
        base.OnTargetReached();
        linkedGrave.ReturnSoul();
        GameLoop.Instance.DecreaseSoulsCount();
        Destroy(gameObject);
    }
}
