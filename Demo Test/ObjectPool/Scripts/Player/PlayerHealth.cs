using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Health
    {
        get; set;
    }

    public bool IsDead { get => Health <= 0; }

    public void TakeDamage(int dmg)
    {
        if (IsDead)
            return;

        Health -= dmg;

        if(IsDead)
        {
            gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        Health = 100;
    }
}
