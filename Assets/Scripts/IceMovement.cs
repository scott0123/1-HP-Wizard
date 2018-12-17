using UnityEngine;
using System.Collections;

public class IceMovement : MonoBehaviour
{
    public AudioClip iceClip;

    private float speed;
    bool exploding = false;
    float explodeTime = 0.2f;
    Color color;

    void Start()
    {
        color = this.GetComponent<MeshRenderer>().material.color;
        if (iceClip != null)
        {
            AudioSource.PlayClipAtPoint(iceClip, this.transform.position, 1.0f);
        }
        else
        {
            Debug.Log("You forgot to attach a sound to the Ice spell!");
        }
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
        this.GetComponent<MeshRenderer>().material.color = new Color(color.r, color.g, color.b, explodeTime);
        this.transform.localScale = Vector3.one * ((0.2f - explodeTime) / 0.2f) * 3;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            speed = 0.0f;
            exploding = true;
            Collider[] explosionVictims = Physics.OverlapSphere(this.transform.position, 2.0F);
            foreach (Collider victim in explosionVictims)
            {
                if (victim.transform.tag != "Enemy")
                    continue;
                victim.transform.SendMessage("Freeze", "Ice");
            }
            Invoke("SelfDestruct", 0.2f);
        }
        else if (other.transform.tag == "Terrain" || other.transform.tag == "Ground")
        {
            SelfDestruct();
        }
    }

    void Move()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
