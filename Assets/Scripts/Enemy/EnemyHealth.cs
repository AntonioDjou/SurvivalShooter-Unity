using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;            // The starting value for enemy's health.
    public int currentHealth;                   // For comparing when he dies.
    public float sinkSpeed = 1.5f;              // The speed at which the enemy sinks through the floor when he dies.
    public int scoreValue = 10;                 // The score added to the Player's Score when the enemy dies - it can be changed in Inspector for each enemy.
    public AudioClip deathClip;                 // The sound played when the enemy dies.


    Animator anim;                              // References the animator.
    AudioSource enemyAudio;                     // References to the enemy hurt audio.
    SphereCollider sphereCollider;              // References to the enemy's sphere collider.
    bool isDead;                                // Whether the enemy is dead.
    bool isSinking;                             // Whether the enemy has started sinking through the floor.


    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        sphereCollider = GetComponent<SphereCollider>();
        // Setting the current health when the enemy first spawns.
        currentHealth = startingHealth;
    }

    void Update()
    {
        if (isSinking) // When the enemy dies
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime); // Move the enemy down by the sinkSpeed per second. Time.deltaTime is used for working with different device's performance
        }
    }

    public void TakeDamage(int amount, Vector3 hitPoint) // Management of what happens when the enemy is hit.
    {
        if (isDead) // If the enemy is dead...
        {
            return; // ... no need to take damage so exit the function.
        }
        enemyAudio.Play(); // Play the hurt sound effect.
        currentHealth -= amount; // Reduce the current health by the amount of damage sustained.
        
        if (currentHealth <= 0) // When the enemy's health is depleted.
        {
            Death(); // Calls the routine for killing it.
        }
    }

    void Death()
    {
        isDead = true;// Bool for starting enemy's death animation (currently not implemented).

        sphereCollider.isTrigger = true; // Turn the collider into a trigger so shots can pass through it.

        anim.SetTrigger("Dead"); // Tell the animator that the enemy is dead.


        //GetComponent<NavMeshAgent>().enabled = false; // Prevents the enemy to move.

        GetComponent<Rigidbody>().isKinematic = true; // Makes the body able to sink through the floor.

        Destroy(gameObject, 2f); // Destroys this object after 2 seconds.

        ScoreManager.score += scoreValue; // Gets the amount of score of the enemy (which changes depending on the enemy) and increments to the player's score.

        isSinking = true; // Trigger the bool for the enemy starting sinking after death's animation is complete.
    }
}
