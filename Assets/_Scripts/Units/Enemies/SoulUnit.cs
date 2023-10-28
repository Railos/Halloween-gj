using System;
using UnityEngine;

public class SoulUnit : MonoBehaviour
{
    public Grave linkedGrave;

    private void FixedUpdate()
    {
        transform.position += transform.right * 0.05f;
    }
}
