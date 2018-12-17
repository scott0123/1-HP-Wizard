using UnityEngine;
using System.Collections;

public class EarthMovement : MonoBehaviour
{
    public AudioClip earthClip;

    private float speed = 0.0f;
    private float time = 0.0f;
    private float topheight;

    void Start()
    {
        topheight = this.transform.position.y + 4.1f;
        speed = 3.0f;
        if (earthClip != null)
        {
            AudioSource.PlayClipAtPoint(earthClip, this.transform.position, 1.0f);
        }
        else
        {
            Debug.Log("You forgot to attach a sound to the Earth spell!");
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        time += Time.deltaTime;
        if (time < 10.0f && this.transform.position.y < topheight)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        else if (time >= 10.0f)
        {
            if (this.transform.position.y < -2)
            {
                Destroy(gameObject);
            }
            transform.position += transform.up * -speed * Time.deltaTime;
        }
    }
}

