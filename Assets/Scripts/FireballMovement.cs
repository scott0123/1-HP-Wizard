using UnityEngine;
using System.Collections;

public class FireballMovement : MonoBehaviour
{

    public AudioClip fireballClip;

    private float speed;
    bool exploding = false;
    float explodeTime = 0.2f;
    void Start()
    {
        AudioSource.PlayClipAtPoint(fireballClip, this.transform.position, 1.0f);
        speed = 5.0f;
        Invoke("SelfDestruct", 10.0f);
    }

    void FixedUpdate()
    {
        if (exploding)
        {
            Explode();
        }
        else
        {
            Move();
        }
    }
    void Explode()
    {
        if (explodeTime > 0.0f)
        {
            explodeTime -= Time.deltaTime;
        }
        this.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, explodeTime);
        this.transform.localScale = Vector3.one * ((0.2f - explodeTime) / 0.2f) * 4;
    }

    void OnTriggerEnter(Collider other)
    {
        speed = 0.0f;
        exploding = true;
        if (other.transform.tag == "Target")
        {
            Collider[] explosionVictims = Physics.OverlapSphere(this.transform.position, 2.0F);
            foreach (Collider victim in explosionVictims)
            {
                victim.transform.SendMessage("Death", "Fireball");
            }
            Invoke("SelfDestruct", 0.2f);
        }
        else
        {
            Collider[] explosionVictims = Physics.OverlapSphere(this.transform.position, 2.0F);
            foreach (Collider victim in explosionVictims)
            {
                victim.transform.SendMessage("GetHit", "Fireball");
            }
            Invoke("SelfDestruct", 0.2f);
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
