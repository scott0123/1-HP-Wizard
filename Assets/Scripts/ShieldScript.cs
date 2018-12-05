using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour {

    float timeLeft;
	// Use this for initialization
	void Start () {
        timeLeft = 0.0f;
        this.GetComponent<Renderer>().enabled = false;
	}

    void GetHit()
    {
        timeLeft -= 5.0f;
    }

    void ActivateShield()
    {
        this.GetComponent<Renderer>().enabled = true;
        timeLeft = 20.0f;
    }

    // Update is called once per frame
    void Update() {
        if (timeLeft > 0.0f)
        {
            timeLeft -= Time.deltaTime;
            float colorRatio = timeLeft / 20.0f;
            this.GetComponent<Renderer>().material.color = new Color(0, 0, 1, colorRatio);
        } else
        {
            this.GetComponent<Renderer>().enabled = false;
        }
	}
}
