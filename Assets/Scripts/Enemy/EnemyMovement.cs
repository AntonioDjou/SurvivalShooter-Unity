using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform player; // References to the player coordinates.
    PlayerHealth playerHealth; // References to the PlayerHealth Script.
    EnemyHealth enemyHealth; // References the EnemyHealth Script.
    UnityEngine.AI.NavMeshAgent nav; // Uses Unity's NavMeshAngent's AI for following the player.

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> (); 
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }

    void Update ()
    {
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0) // If both enemy and player are alive.
        {
            nav.SetDestination (player.position); // Goes for player's position.
        }
        else
        {
            nav.enabled = false;
        }
    }
}
