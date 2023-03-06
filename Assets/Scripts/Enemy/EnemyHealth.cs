using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private List<GameObject> items;
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject lootPrefab; // The prefab that will be spawned as loot when the enemy dies

    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        currentHealth = maxHealth;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Update()
    {
        
    }

   
 
    void Die()
    {
        // Spawn the loot prefab at the enemy's position
        GameObject loot = Instantiate(lootPrefab, transform.position, Quaternion.identity);
        loot.GetComponent<LootScript>().addItems(items);
        // Destroy the enemy game object
        Destroy(gameObject);
    }
}
