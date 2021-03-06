﻿using UnityEngine;
using System.Collections;

public class LightningMovement : MonoBehaviour
{
    public AudioClip lightningClip;

    private float speed;

    void Start()
    {
        if (lightningClip != null)
        {
            AudioSource.PlayClipAtPoint(lightningClip, this.transform.position, 1.0f);
        }
        else
        {
            Debug.Log("You forgot to attach a sound to the Lightning spell!");
        }
        speed = 10.0f; ;
        Invoke("SelfDestruct", 10.0f);
    }

    private void FixedUpdate()
    {
        Move();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Enemy")
        {
            other.transform.SendMessage("GetHit", "Lightning");
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

    void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
