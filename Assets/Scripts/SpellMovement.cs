using UnityEngine;
using System.Collections;

public class SpellMovement : MonoBehaviour {

	private float speed;

    void Start()
    {
		speed = 5.0f;
		Invoke ("SelfDestruct", 10.0f);
	}
    
    void Update(){
        Move();
    }

	void OnTriggerEnter(Collider other){
		
		if (other.transform.tag == "Target") {
			other.transform.SendMessage ("Death", "Spell");
		}
	}

    void Move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

	void SelfDestruct(){
		Destroy (gameObject);
	}
}
