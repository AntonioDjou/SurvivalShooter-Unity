using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour
{
    Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) // Check if the Escape key has being pressed
        {
            canvas.enabled = !canvas.enabled; // Flip from enable to disable or vice-versa
            Pause();
        }
    }

    public void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0; // If it's currently set to 0, set to 1. Otherwise, set to 0 
    }

    public void Quit()
    {

#if UNITY_EDITOR
    EditorApplication.isPlaying = false; //Gonna stop playing the scene
#else
    Application.Quit();
#endif
    }
}
