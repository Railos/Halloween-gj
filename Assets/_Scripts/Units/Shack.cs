using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shack : MonoBehaviour, IDamageable
{
    public float hp, maxHp;

    [SerializeField] private List<GameObject> sprites;

    [SerializeField] private AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
    }

    
    public void GetDamage(float damage)
    {
        hp -= damage;
        AudioSystem.Instance.PlaySound(sound);
        if (hp <= 65)
        {
            sprites[0].SetActive(false);
            sprites[1].SetActive(true);
        }
        if (hp <= 35)
        {
            sprites[1].SetActive(false);
            sprites[2].SetActive(true);
        }
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameLoop.Instance.GameOver();
    }
}
