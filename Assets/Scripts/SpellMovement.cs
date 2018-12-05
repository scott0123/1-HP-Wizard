using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SpellMovement : MonoBehaviour {

	private float speed;

    void Start()
    {
		speed = 5.0f;
		Invoke ("SelfDestruct", 10.0f);
	}
    
    void FixedUpdate(){
        Move();
    }

	void OnTriggerEnter(Collider other){
        if (other.transform.tag == "Target") {
			other.transform.SendMessage ("Death", "Spell");
            SelfDestruct();
        }

        if (other.transform.tag == "Player")
        {
            //temporary, for testing
            SelfDestruct();
            Debug.Log("You Died.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        else if (other.transform.tag == "Enemy")
        {
            other.transform.SendMessage("GetHit", "Spell");
            SelfDestruct();
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
