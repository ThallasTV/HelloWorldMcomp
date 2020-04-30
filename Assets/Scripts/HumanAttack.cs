using UnityEngine;


public class HumanAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack
    public int attackDamage = 10;               // The amount of damage taken per attack
    bool animalInRange;                         // Whether animal is within the trigger collider and can be attacked
    float timer;                                // Timer for counting up to the next attack

    GameObject animal;                          // Reference to this animal GameObject
    Health animalHealth;                        // Reference to this animal's health
    Health humanHealth;                         // Reference to this human's health


    void Awake()
    {
        // Find tags of "Animal" to get their game objects
        animal = GameObject.FindGameObjectWithTag("Animal");
        
        animalHealth = animal.GetComponent<Health>();
        humanHealth = gameObject.GetComponent<Health>();
    }


    void OnTriggerEnter(Collider col)
    {
        // If the human collides with an animal, they are in range to be attacked
        if (col.gameObject == animal)
        {
            animalInRange = true;
            Debug.Log(animalInRange);
        }
    }


    void OnTriggerExit(Collider col)
    {
        // If the human isn't colliding with an animal, they are no longer in range to attack
        if (col.gameObject == animal)
        {
            animalInRange = false;
            Debug.Log(animalInRange);
        }
    }


    void Update()
    {
        // Add the time since Update was last called to the timer
        timer += Time.deltaTime;

        Debug.Log(animalHealth.currentHealth);
        Debug.Log(animalInRange);

        // If the timer exceeds the time between attacks, the animal is in range and this human is alive, switch to Attack function
        if (timer >= timeBetweenAttacks && animalInRange && humanHealth.currentHealth > 0)
        {
            Attack();
        }
    }


    void Attack()
    {
        // Resets the timer
        timer = 0f;

        // If the animal is still alive, deal damage to it
        if (animalHealth.currentHealth > 0)
        {
            animalHealth.TakeDamage(attackDamage);
        }
    }
}