using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour {

    public AudioClip shieldClip;

    float timeLeft;
	// Use this for initialization
	void Start () {
        timeLeft = 0.0f;
        this.GetComponentInChildren<Renderer>().enabled = false;
        this.GetComponent<BoxCollider>().enabled = false;
	}

    void GetHit()
    {
        timeLeft -= 5.0f;
    }

    void Activate()
    {
        WandColor.updateColor("Shield");
        timeLeft = float.MinValue;
        this.GetComponentInChildren<Renderer>().enabled = true;
        this.GetComponentInChildren<Renderer>().material.color = new Color(0, 1, 0, 0.9f);
    }

    void Cast()
    {
        AudioSource.PlayClipAtPoint(shieldClip, this.transform.position, 1.0f);
        this.GetComponent<BoxCollider>().enabled = true;
        timeLeft = 20.0f;
        WandColor.updateColor("");
        //if (CastSound != null)
        //{
        //    AudioSource.PlayClipAtPoint(CastSound, this.transform.position, 0.5f);
        //}
        //else
        //{
        //    Debug.Log("You forgot to attach a Activateing sound to SpellControl!");
        //}
    }

    // Update is called once per frame
    void Update() {
        if (timeLeft > 0.0f)
        {
            timeLeft -= Time.deltaTime;
            float colorRatio = timeLeft / 20.0f;
            this.GetComponentInChildren<Renderer>().material.color = new Color(0, 1, 0, colorRatio);
        } else if (timeLeft != float.MinValue)
        {
            this.GetComponentInChildren<Renderer>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
        }
	}
}
