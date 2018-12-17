using UnityEngine;
using System.Collections;

public class EarthMovement : MonoBehaviour
{
    public AudioClip earthClip;

    private float speed = 0.0f;
    private float time = 0.0f;

    void Start()
    {
        Color color = this.GetComponent<Renderer>().material.color;
        this.GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, 0.1f);
    }

    void FixedUpdate()
    {
        if (this.GetComponent<Rigidbody>().detectCollisions == true)
        {
            Move();
        }
    }

    void Cast()
    {
        AudioSource.PlayClipAtPoint(earthClip, this.transform.position, 1.0f);
        Color color = this.GetComponent<Renderer>().material.color;
        this.GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, 1);
        this.transform.position += Vector3.down * 4.1f;
        speed = 3.0f;
    }

    void Move()
    {
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

