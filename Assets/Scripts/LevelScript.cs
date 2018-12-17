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

    public static int level = 2;

    // Use this for initialization
    void Start () {
        if (level == 0)
            EnemyWizard.minionCount = -2;
        else if (level == 1)
            EnemyWizard.minionCount = 6;
        else if (level == 2)
            EnemyWizard.minionCount = 10;
        else if (level == 3)
            EnemyWizard.minionCount = 20;
        spawnInterval = 12.0f;
        spawnTimer = 5;
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
                EnemyWizard.minionCount = 6; //arbitrary
                SceneManager.LoadScene("Level1", LoadSceneMode.Single);
            } else if (level == 2)
            {
                EnemyWizard.minionCount = 10; //arbitrary
                SceneManager.LoadScene("Level2", LoadSceneMode.Single);
            } else
            {
                EnemyWizard.minionCount = 20; //arbitrary
                SceneManager.LoadScene("Level3", LoadSceneMode.Single);
            }
        }

        if (level == 1)
        {
            Level1();
        } else if (level == 2)
        {
            Level2();
        } else if (level == 3)
        {
            Level3();
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
                GameObject instanceJaguar = Instantiate(jaguar, new Vector3(6, 1, 36), Quaternion.identity);
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

    void Level1()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            if (wave == 0)
            {
                GameObject instanceBear = Instantiate(bear, new Vector3(5, 1, 33), Quaternion.identity);
                instanceBear.GetComponent<Bear>().player = player;
                GameObject instanceJaguar = Instantiate(jaguar, new Vector3(6, 1, 36), Quaternion.identity);
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

    void Level2()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            if (wave == 0)
            {
                GameObject instanceBear = Instantiate(bear, new Vector3(-51, 10, -8), Quaternion.identity);
                instanceBear.GetComponent<Bear>().player = player;
                GameObject instanceJaguar = Instantiate(jaguar, new Vector3(-49, 10, -9), Quaternion.identity);
                instanceJaguar.GetComponent<Jaguar>().player = player;
                GameObject instanceBear1 = Instantiate(bear, new Vector3(56, 6, 2), Quaternion.identity);
                instanceBear1.GetComponent<Bear>().player = player;
            }
            else if (wave == 1)
            {
                GameObject instanceBear = Instantiate(bear, new Vector3(-51, 10, -8), Quaternion.identity);
                instanceBear.GetComponent<Bear>().player = player;

                GameObject instanceInferno = Instantiate(inferno, new Vector3(56, 6, 2), Quaternion.identity);
                instanceInferno.GetComponent<FireDemon>().player = player;
            }
            else if (wave == 2)
            {
                GameObject instanceJaguar = Instantiate(jaguar, new Vector3(-49, 10, -9), Quaternion.identity);
                instanceJaguar.GetComponent<Jaguar>().player = player;

                GameObject instanceImp0 = Instantiate(imp, new Vector3(56, 6, 2), Quaternion.identity);
                instanceImp0.GetComponent<Imp>().player = player;
                GameObject instanceImp1 = Instantiate(imp, new Vector3(54, 6, 0), Quaternion.identity);
                instanceImp1.GetComponent<Imp>().player = player;
                GameObject instanceImp2 = Instantiate(imp, new Vector3(55, 6, 1), Quaternion.identity);
                instanceImp2.GetComponent<Imp>().player = player;
            }
            else if (wave == 3)
            {
                GameObject instanceInferno = Instantiate(inferno, new Vector3(-49, 10, -9), Quaternion.identity);
                instanceInferno.GetComponent<FireDemon>().player = player;

                GameObject instanceInferno2 = Instantiate(inferno, new Vector3(56, 6, 2), Quaternion.identity);
                instanceInferno2.GetComponent<FireDemon>().player = player;
            }
            else
            {
                GameObject instanceWizard = Instantiate(wizard, new Vector3(-49, 10, -9), Quaternion.identity);
                instanceWizard.GetComponent<EnemyWizard>().player = player;
            }
            spawnTimer = spawnInterval;
            wave++;
        }
    }

    void Level3()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            if (wave == 0)
            {
                GameObject instanceBear = Instantiate(bear, new Vector3(24, 20, 45), Quaternion.identity);
                instanceBear.GetComponent<Bear>().player = player;
                GameObject instanceJaguar = Instantiate(jaguar, new Vector3(-47, 22, 8), Quaternion.identity);
                instanceJaguar.GetComponent<Jaguar>().player = player;
                GameObject instanceBear1 = Instantiate(bear, new Vector3(49, 20, 26), Quaternion.identity);
                instanceBear1.GetComponent<Bear>().player = player;
            }
            else if (wave == 1)
            {
                GameObject instanceJaguar = Instantiate(jaguar, new Vector3(-47, 22, 8), Quaternion.identity);
                instanceJaguar.GetComponent<Jaguar>().player = player;
                GameObject instanceJaguar1 = Instantiate(jaguar, new Vector3(-32, 23, -44), Quaternion.identity);
                instanceJaguar1.GetComponent<Jaguar>().player = player;

                GameObject instanceImp0 = Instantiate(imp, new Vector3(21, 23, 47), Quaternion.identity);
                instanceImp0.GetComponent<Imp>().player = player;
                GameObject instanceImp1 = Instantiate(imp, new Vector3(20, 23, 46), Quaternion.identity);
                instanceImp1.GetComponent<Imp>().player = player;
                GameObject instanceImp2 = Instantiate(imp, new Vector3(20, 23, 45), Quaternion.identity);
                instanceImp2.GetComponent<Imp>().player = player;
                GameObject instanceImp3 = Instantiate(imp, new Vector3(21, 23, 45), Quaternion.identity);
                instanceImp3.GetComponent<Imp>().player = player;
            }
            else if (wave == 2)
            {
                GameObject instanceBear = Instantiate(bear, new Vector3(49, 20, 27), Quaternion.identity);
                instanceBear.GetComponent<Bear>().player = player;

                GameObject instanceInferno = Instantiate(inferno, new Vector3(65, 20, 11), Quaternion.identity);
                instanceInferno.GetComponent<FireDemon>().player = player;

                GameObject instanceImp0 = Instantiate(imp, new Vector3(21, 23, 47), Quaternion.identity);
                instanceImp0.GetComponent<Imp>().player = player;
                GameObject instanceImp1 = Instantiate(imp, new Vector3(20, 23, 46), Quaternion.identity);
                instanceImp1.GetComponent<Imp>().player = player;
                GameObject instanceImp2 = Instantiate(imp, new Vector3(20, 23, 45), Quaternion.identity);
                instanceImp2.GetComponent<Imp>().player = player;
                GameObject instanceImp3 = Instantiate(imp, new Vector3(21, 23, 45), Quaternion.identity);
                instanceImp3.GetComponent<Imp>().player = player;
            }
            else if (wave == 3)
            {
                GameObject instanceInferno = Instantiate(inferno, new Vector3(23, 20, 47), Quaternion.identity);
                instanceInferno.GetComponent<FireDemon>().player = player;

                GameObject instanceInferno2 = Instantiate(inferno, new Vector3(24, 20, 45), Quaternion.identity);
                instanceInferno2.GetComponent<FireDemon>().player = player;

                GameObject instanceBear = Instantiate(bear, new Vector3(49, 20, 27), Quaternion.identity);
                instanceBear.GetComponent<Bear>().player = player;
                GameObject instanceJaguar = Instantiate(jaguar, new Vector3(-47, 22, 8), Quaternion.identity);
                instanceJaguar.GetComponent<Jaguar>().player = player;
            }
            else
            {
                GameObject instanceWizard = Instantiate(wizard, new Vector3(24, 20, 45), Quaternion.identity);
                instanceWizard.GetComponent<EnemyWizard>().player = player;
            }
            spawnTimer = spawnInterval;
            wave++;
        }
    }
}
