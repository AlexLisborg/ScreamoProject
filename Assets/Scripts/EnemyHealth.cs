using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject lootPrefab; // The prefab that will be spawned as loot when the enemy dies

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Spawn the loot prefab at the enemy's position
        Instantiate(lootPrefab, transform.position, Quaternion.identity);

        // Destroy the enemy game object
        Destroy(gameObject);
    }
}
