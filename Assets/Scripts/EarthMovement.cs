using UnityEngine;
using System.Collections;

public class EarthMovement : MonoBehaviour
{
    public GameObject pillar;
    private float speed;

    void Start()
    {
        speed = 5.0f;
        Invoke("SelfDestruct", 10.0f);
    }

    void FixedUpdate()
    {
        Move();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            print("hit ground");
            GameObject instance = Instantiate(pillar, this.transform.position + (Vector3.down * 2.1f), Quaternion.identity);
        }
        else if (other.tag == "Terrain")
        {
            SelfDestruct();
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
