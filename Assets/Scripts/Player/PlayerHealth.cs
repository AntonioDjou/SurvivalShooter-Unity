using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider; // Changes the value in the UI so the player's health depletes as he gets hit.
    public Image damageImage; // For showing an red image at the screen when the player is hit.
    //public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(.45f, 0.05f, 0.05f, 0.1f);


    Animator anim;
    AudioSource playerAudio;
    PlayerShooting playerShooting; // PlayerShooting refers to the Script while playerShooting is the name of the variable
    bool isDead;
    bool damaged;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        playerAudio = GetComponent <AudioSource> ();
        playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;
    }


    void Update ()
    {
        if(damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }


    public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth; // healthSlider value is updated with player's current health.

        //playerAudio.Play (); // Plays the audio when the player is hurt.

        if(currentHealth <= 0 && !isDead)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        //playerShooting.DisableEffects (); // The player can not shoot anymore.

        anim.SetTrigger ("Die");
        playerAudio.Play ();

        playerShooting.enabled = false;
    }


    public void RestartLevel ()
    {
        SceneManager.LoadScene ("Level1");
    }
}
