using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;

    public event Action onDead;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            if (onDead != null)
            {
                onDead();
            }

            Destroy(gameObject);
        }
    }
}