using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarScript : MonoBehaviour {

    private float time = 0.0f;
    private float speed = 3.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
		if (time < 10.0f && this.transform.position.y < 2)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        else if (time >= 10.0f)
        {
            if (this.transform.position.y < -2)
            {
                Destroy(this);
            }
            transform.position += transform.up * -speed * Time.deltaTime;
        }
	}
}
