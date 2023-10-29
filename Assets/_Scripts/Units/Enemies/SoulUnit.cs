using System;
using DG.Tweening;
using Pathfinding;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoulUnit : AIPath
{
    public Grave linkedGrave;

    private void Start()
    {
        GetComponent<SpriteRenderer>().DOFade(0f, 0f).OnComplete(() => GetComponent<SpriteRenderer>().DOFade(1f, 1f).SetEase(Ease.InOutCubic));
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
