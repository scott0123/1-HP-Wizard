using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SpellMovement : MonoBehaviour {

    public AudioClip spellClip;


    private float speed;

    void Start()
    {
        if (spellClip != null)
        {
            AudioSource.PlayClipAtPoint(spellClip, this.transform.position, 1.0f);
        }
        else
        {
            Debug.Log("You forgot to attach a sound to the Lightning spell!");
        }
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

        else if (other.transform.tag == "Enemy")
        {
            other.transform.SendMessage("GetHit", "Spell");
            SelfDestruct();
        }

        else if (other.transform.tag == "Terrain" || other.transform.tag == "Ground")
        {
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
