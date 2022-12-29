using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f; // The time for enemy attack again - it can be changed in Inspector for each enemy.
    public int attackDamage = 10; // The amount of damage caused to player's health - it can be changed in Inspector for each enemy.

    Animator anim; // References the animator.
    GameObject player; // References the player.
    PlayerHealth playerHealth; // References the PlayerHealth Script.
    EnemyHealth enemyHealth; // References the EnemyHealth Script.

    bool playerInRange; // Measures the distance of both enemy and player's colliders.
    float timer; // Counts the time to be compared of enemy's timeBetweenAttacks.

    void Awake ()
    {
        // Setting up the references.
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
    }

    void OnTriggerEnter (Collider other) // When a collision is detected.
    {
        if(other.gameObject == player) // If the object touched is the player.
        {
            playerInRange = true; // Sets up that the player is in range for attacking.
        }
    }

    void OnTriggerExit (Collider other) // Exits the range so the player won't keep getting hit.
    {
        if(other.gameObject == player)
        {
            playerInRange = false; // The player can only be hit again after the timer is filled.
        }
    }

    void Update ()
    {
        timer += Time.deltaTime; // Starts adding the time to be compared if the enemy is ready for next attack.

        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0) // also compares if enemy is not dead.
        {
            Attack (); // Calls the attack routine.
        }

        if(playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger ("PlayerDead"); // Plays the PlayerDead animation. (Currently not implemented yet)
        }
    }

    void Attack ()
    {
        timer = 0f; // Restarts the timer before attacking again.

        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage (attackDamage); // The TakeDamage routine in playerHealth requires a variable with the amount of damage caused.
        }
    }
}
