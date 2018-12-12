using UnityEngine;
using System.Collections;

public class IceMovement : MonoBehaviour
{

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

        if (other.transform.tag == "Target")
        {
            Collider[] explosionVictims = Physics.OverlapSphere(this.transform.position, 2.0F);
            foreach (Collider victim in explosionVictims)
            {
                victim.transform.SendMessage("Freeze", "Ice");
            }
            SelfDestruct();
        }
        else
        {
            Collider[] explosionVictims = Physics.OverlapSphere(this.transform.position, 2.0F);
            foreach (Collider victim in explosionVictims)
            {
                victim.transform.SendMessage("Freeze", "Ice");
            }
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
