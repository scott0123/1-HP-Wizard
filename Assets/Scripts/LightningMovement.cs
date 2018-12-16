﻿using UnityEngine;
using System.Collections;

public class LightningMovement : MonoBehaviour
{

    private float speed;
    public AudioSource lightningSoundSource;
    public AudioClip lightningSound;

    void Start()
    {
        speed = 50.0f; ;
        Invoke("SelfDestruct", 10.0f);
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
            other.transform.SendMessage("GetHit", "Lightning");
        }
        else if (other.transform.tag == "Terrain")
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
