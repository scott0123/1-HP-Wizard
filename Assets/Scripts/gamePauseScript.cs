using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamePauseScript : MonoBehaviour {

    bool isPaused = false;
    public GameObject pauseMenu;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 1f : 0f;
            
            pauseMenu.SetActive(isPaused);

        }

        if (isPaused && OVRInput.GetDown(OVRInput.Button.Three))
        {
            // X pushed, continue game
            isPaused = false;
            Time.timeScale = 1f;
        }

        if (isPaused && OVRInput.GetDown(OVRInput.Button.Four))
        {
            // Y pushed, end game
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }
}
