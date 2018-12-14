using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirMovement : MonoBehaviour {

    // Use this for initialization
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
