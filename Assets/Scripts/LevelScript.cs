using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour {

    public GameObject wizard;
    public GameObject imp;
    public GameObject inferno;
    public GameObject bear;
    public GameObject jaguar;
    public GameObject player;
    protected double spawnInterval;
    protected double spawnTimer;
    private int wave;

    private static int level = 0;

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
        if (EnemyWizard.minionCount <= -2)
        {
            level++;
            wave = 0;

            if (level == 1)
            {
                SceneManager.LoadScene("Level1", LoadSceneMode.Single);
                EnemyWizard.minionCount = 10; //arbitrary
            } else if (level == 2)
            {
                SceneManager.LoadScene("Level2", LoadSceneMode.Single);
                EnemyWizard.minionCount = 10; //arbitrary
            } else
            {

            }
        }

        if (level == 0)
        {
            Level0();
        } else if (level == 1)
        {
            Level1();
        } else
        {

        }
    }

    void Level0()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            if (wave == 0)
            {
                GameObject instanceBear = Instantiate(bear, new Vector3(5, 1, 33), Quaternion.identity);
                instanceBear.GetComponent<Bear>().player = player;
                //GameObject instanceJaguar = Instantiate(jaguar, new Vector3(5, 1, 32), Quaternion.identity);
                //instanceJaguar.GetComponent<Jaguar>().player = player;
            }
            else if (wave == 1)
            {
                GameObject instanceImp0 = Instantiate(imp, new Vector3(4, 4.2f, 31), Quaternion.identity);
                instanceImp0.GetComponent<Imp>().player = player;
                GameObject instanceImp1 = Instantiate(imp, new Vector3(4, 4, 32), Quaternion.identity);
                instanceImp1.GetComponent<Imp>().player = player;
                GameObject instanceImp2 = Instantiate(imp, new Vector3(4, 3.8f, 33), Quaternion.identity);
                instanceImp2.GetComponent<Imp>().player = player;

                GameObject instanceInferno = Instantiate(inferno, new Vector3(4.2f, 1, 32), Quaternion.identity);
                instanceInferno.GetComponent<FireDemon>().player = player;
            }
            else if (wave == 2)
            {
                GameObject instanceWizard = Instantiate(wizard, new Vector3(4, 1, 32), Quaternion.identity);
                instanceWizard.GetComponent<EnemyWizard>().player = player;
            }
            spawnTimer = spawnInterval;
            wave++;
        }
    }

    void Level1()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            if (wave == 0)
            {
                GameObject instanceBear = Instantiate(bear, new Vector3(4, 1, 31), Quaternion.identity);
                instanceBear.GetComponent<Bear>().player = player;
                GameObject instanceJaguar = Instantiate(jaguar, new Vector3(4, 1, 32), Quaternion.identity);
                instanceJaguar.GetComponent<Jaguar>().player = player;
            }
            else if (wave == 1)
            {
                GameObject instanceImp0 = Instantiate(imp, new Vector3(4, 4.2f, 31), Quaternion.identity);
                instanceImp0.GetComponent<Imp>().player = player;
                GameObject instanceImp1 = Instantiate(imp, new Vector3(4, 4, 32), Quaternion.identity);
                instanceImp1.GetComponent<Imp>().player = player;
                GameObject instanceImp2 = Instantiate(imp, new Vector3(4, 3.8f, 33), Quaternion.identity);
                instanceImp2.GetComponent<Imp>().player = player;

                GameObject instanceInferno = Instantiate(inferno, new Vector3(4.2f, 1, 32), Quaternion.identity);
                instanceInferno.GetComponent<FireDemon>().player = player;
            }
            else if (wave == 2)
            {
                GameObject instanceWizard = Instantiate(wizard, new Vector3(4, 1, 32), Quaternion.identity);
                instanceWizard.GetComponent<EnemyWizard>().player = player;
            }
            spawnTimer = spawnInterval;
            wave++;
        }
    }
}
