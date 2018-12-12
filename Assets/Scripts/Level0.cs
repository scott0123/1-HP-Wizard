using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0 : MonoBehaviour {

    public GameObject wizard;
    public GameObject imp;
    public GameObject inferno;
    public GameObject bear;
    public GameObject jaguar;
    public GameObject player;
    protected double spawnInterval;
    protected double spawnTimer;
    private int wave;

    // Use this for initialization
    void Start () {
        EnemyWizard.minionCount = 6;
        spawnInterval = 5.0f;
        spawnTimer = spawnInterval;
        wave = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            if (wave == 0)
            {
                GameObject instanceBear = Instantiate(bear, new Vector3(10, 0, 40), Quaternion.identity);
                instanceBear.GetComponent<Bear>().player = player;
                GameObject instanceJaguar = Instantiate(jaguar, new Vector3(-10, 0, 40), Quaternion.identity);
                instanceJaguar.GetComponent<Jaguar>().player = player;
            }
            else if (wave == 1)
            {
                GameObject instanceImp0 = Instantiate(imp, new Vector3(10, 0, 40), Quaternion.identity);
                instanceImp0.GetComponent<Imp>().player = player;
                GameObject instanceImp1 = Instantiate(imp, new Vector3(9, 0, 40), Quaternion.identity);
                instanceImp1.GetComponent<Imp>().player = player;
                GameObject instanceImp2 = Instantiate(imp, new Vector3(11, 0, 40), Quaternion.identity);
                instanceImp2.GetComponent<Imp>().player = player;

                GameObject instanceInferno = Instantiate(inferno, new Vector3(-10, 0, 40), Quaternion.identity);
                instanceInferno.GetComponent<FireDemon>().player = player;
            }
            else if (wave == 2)
            {
                GameObject instanceWizard = Instantiate(wizard, new Vector3(0, 0, 40), Quaternion.identity);
                instanceWizard.GetComponent<EnemyWizard>().player = player;
            }
            spawnTimer = spawnInterval;
            wave++;
        }
    }
}
