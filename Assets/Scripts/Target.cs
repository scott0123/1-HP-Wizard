using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

    void Death(string killer)
    {

        //destroy itself by disabling it
        gameObject.SetActive(false);
        // reenable it in 5 seconds
        Invoke("ReenableTarget", 1);
    }

    void ReenableTarget()
    {
        gameObject.SetActive(true);
    }
}
