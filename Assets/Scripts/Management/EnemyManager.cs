using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f; // 3 seconds between spawning next enemy - can be changed for every enemy type.
    public Transform[] spawnPoints; // Stores the location for that enemy type spawn.

   
    public void OnObjectSpawn ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime); // When the game starts, wait for the Spawn Time so it can begins to spawn enemies.
    }

    void Spawn ()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return; // Do not spawn enemies if the player is dead.
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length); // Chooses one of the spawn points and keeps which one was picked at the spawnPointIndex integer.

        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation); // Creates an enemy at the spawn point and in the rotation determined.
    }
}
