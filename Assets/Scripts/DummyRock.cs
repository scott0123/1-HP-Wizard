using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyRock : MonoBehaviour {

    Vector3 moveDir;
    float elapsedTime;
    float timeToChange;

    public GameObject player;
    public GameObject tutorial;

    private Tutorial tut;
    private SpellControl sc;

    // Use this for initialization
    void Start () {
        moveDir = transform.right;
        elapsedTime = 1.0f;
        timeToChange = 2.0f;

        tut = tutorial.GetComponent<Tutorial>();
        sc = player.GetComponent<SpellControl>();
    }
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 2.0f)
        {
            elapsedTime = 0.0f;
            moveDir = -moveDir;
        }
        transform.Translate(moveDir * 0.3f * Time.deltaTime, Space.World);

        DetectTrigger();
    }

    void DetectTrigger()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            if (tut.stage == 7 && sc.primedSpell == "Lightning")
            {
                tut.SendMessage("NextStage");
            }
            else if (tut.stage == 8 && sc.primedSpell == "Earth")
            {
                tut.SendMessage("NextStage");
            }
            else if (tut.stage == 10 && sc.primedSpell == "Air")
            {
                tut.SendMessage("NextStage");
            }
            else if (tut.stage == 11 && sc.primedSpell == "Shield")
            {
                tut.SendMessage("NextStage");
            }
        }
    }

    void GetHit(string source)
    {
        Debug.Log(source + " " + tut.stage);
        // Spell represents point and shoot for now
        switch (tut.stage)
        {
            case 5:
                if (source == "Spell")
                    tut.SendMessage("NextStage");
                break;
            case 6:
                if (source == "Fireball")
                    tut.SendMessage("NextStage");
                break;
            default:
                break;
        }

    }

    void Freeze(string source)
    {
        switch (tut.stage)
        {
            case 9:
                if (source == "Ice")
                    tut.SendMessage("NextStage");
                break;
            default:
                break;
        }
    }
}
