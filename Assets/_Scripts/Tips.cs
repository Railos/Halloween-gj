using System;
using UnityEngine;

public class Tips : MonoBehaviour
{

    public float timeToDestroy;

    private void Start()
    {
        Invoke(nameof(DestroyAll), timeToDestroy);
    }

    private void DestroyAll()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
