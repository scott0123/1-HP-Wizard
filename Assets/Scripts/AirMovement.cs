using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirMovement : MonoBehaviour {

    // Use this for initialization
    public AudioClip airClip;

    private float speed;

	void Start () {
        this.GetComponent<Renderer>().material.color = new Color(0, 0, 0.1f, 0.1f);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
    }

    void Cast()
    {
        if (airClip != null)
        {
            AudioSource.PlayClipAtPoint(airClip, this.transform.position, 1.0f);
        }
        else
        {
            Debug.Log("You forgot to attach a sound to the Air spell!");
        }
        speed = 10.0f;
        Invoke("SelfDestruct", 10.0f);
    }

    void Move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
