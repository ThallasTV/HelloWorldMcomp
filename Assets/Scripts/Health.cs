using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    public int startingHealth = 100;            // The amount of health the character starts the game with
    public int currentHealth;                   // The current health the character has
    bool isDead;                                // Whether the character is dead


    void Awake()
    {
        // Setting the current health when the character first spawns
        currentHealth = startingHealth;
    }


    public void TakeDamage(int amount)
    {
        // If the character is dead, exit the function
        if (isDead)
            return;

        // Reduce the current health by the amount of from the enemy
        currentHealth -= amount;

        // If the current health is less than or equal to zero, run Death() function
        if (currentHealth <= 0)
            Death();
    }


    void Death()
    {
        isDead = true;

        Debug.Log("Dead");

        // Find and disable the Nav Mesh Agent
        GetComponent<NavMeshAgent>().enabled = false;

        // After 2 seconds destroy the character
        Destroy(gameObject, 2f);
    }
}