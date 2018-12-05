using UnityEngine;
using System.Collections;

public class LightningMovement : MonoBehaviour
{

    private float speed;

    void Start()
    {
        speed = 0.0f;
        Invoke("SelfDestruct", 10.0f);
    }

    void Update()
    {
        if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
        {
            this.transform.SetParent(null);
            speed = 10.0f;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Target")
        {
            other.transform.SendMessage("Death", "Lightning");
        }
        else if (other.transform.tag == "Enemy")
        {
            other.transform.SendMessage("GetHit", "Spell");
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
