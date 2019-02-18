using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth = 100f;
    public float damage = 100f;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            currentHealth -= damage;

            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        if (currentHealth < 1)
        {
            Destroy(gameObject);
        }
    }
}