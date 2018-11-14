using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemySpellMovement : MonoBehaviour
{

    private float speed;

    void Start()
    {
        speed = 5.0f;
        Invoke("SelfDestruct", 10.0f);
    }

    void Update()
    {
        Move();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Shield")
        {
            other.transform.SendMessage("GetHit", "Spell");
            SelfDestruct();
        }

        else if (other.transform.tag == "Player")
        {
            Debug.Log("You Died.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
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
