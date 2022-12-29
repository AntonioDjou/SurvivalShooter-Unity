using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score; // This variable needs to be static as it is a global value. Different from enemyHealth, that every enemy will have it's own.
    Text text;

    void Awake ()
    {
        text = GetComponent <Text> ();
        score = 0; // Resets the score
    }

    void Update ()
    {
        text.text = "Score: " + score; // Writes down Score: and gets the value of the variable 'score', which value will be updated with every enemy killed. 
    }
}
