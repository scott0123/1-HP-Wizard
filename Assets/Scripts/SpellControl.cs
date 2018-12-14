using UnityEngine;
using UnityEditor;
using System.Collections;

public class SpellControl : MonoBehaviour {

    public AudioClip CastSound;
    public GameObject spell;
    public GameObject fireball;
    public GameObject earth;
    public GameObject ice;
    public GameObject air;
    public GameObject lightning;
    public GameObject wand;
    public GameObject wandTip;
    public GameObject shield;
    public GameObject lightningLine;
    GameObject instance = null;
    

    public string primedSpell = "";

    private float wandLength;
    private int mana;


    private double manaRegenInterval;
    private double manaRegenTimer;

    void Start(){
        mana = 20;
		wandLength = 0.15f;

        manaRegenInterval = 1.0f;
        manaRegenTimer = 1.0f;
}
	void Update() {
        manaRegenTimer -= Time.deltaTime;
        if (manaRegenTimer <= 0.0f)
        {
            if (mana < 20)
                mana++;
            manaRegenTimer = manaRegenInterval;
        }
        DetectTrigger();
    }

    void DetectTrigger()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {
            if (primedSpell != "")
            {
                Invoke("Cast" + primedSpell, 0.0f);
                primedSpell = "";
            } else
            {
                CastSpell();
            }
        }
        else if (primedSpell != "")
        {
            Invoke("Activate" + primedSpell, 0.0f);
        }

    }
    
	void CastSpell() {
        if (mana >= 1)
        {
            Quaternion wand_quat = Quaternion.Euler(new Vector3(-30.0f, 0, 0));
            GameObject instance = Instantiate(spell, wand.transform.position + wand.transform.up * (wandLength / 2 + 0.1f), wand.transform.rotation * wand_quat);
            if (CastSound != null)
            {
                AudioSource.PlayClipAtPoint(CastSound, instance.transform.position, 0.5f);
            }
            else
            {
                Debug.Log("You forgot to attach a Casting sound to SpellControl!");
            }

            mana--;
        }
    }

    void ActivateAir()
    {
        WandColor.updateColor("Air");
        Vector3 wandAngle = new Vector3(0, wand.transform.rotation.eulerAngles.y, 0);
        Quaternion direction = Quaternion.Euler(wandAngle);
        Ray ray = new Ray(new Vector3(wand.transform.position.x, 2, wand.transform.position.z), Quaternion.Euler(wandAngle) * transform.forward);
        Vector3 airLocation = ray.GetPoint(3);
        if (instance == null)
        {
            instance = Instantiate(air, airLocation, direction);
            instance.GetComponent<Rigidbody>().detectCollisions = false;
        } else
        {
            instance.transform.position = airLocation;
            instance.transform.rotation = direction;
        }
    }

    void CastAir()
    {
        WandColor.updateColor("");
        instance.GetComponent<Rigidbody>().detectCollisions = true;
        instance.SendMessage("Cast");
        instance = null;
        if (CastSound != null)
        {
            AudioSource.PlayClipAtPoint(CastSound, instance.transform.position, 0.5f);
        }
        else
        {
            Debug.Log("You forgot to attach a Casting sound to SpellControl!");
        }
    }

    void ActivateFireball()
    {
        if (mana >= 5)
        {
            WandColor.updateColor("Fireball");
            mana -= 5;
        }
    }

    void CastFireball()
    {
        WandColor.updateColor("");
        wandTip.GetComponent<WandColor>().SendMessage("updateColor", "Fireball");
        Quaternion wand_quat = Quaternion.Euler(new Vector3(-30.0f, 0, 0));
        GameObject instance = Instantiate(fireball, wand.transform.position + wand.transform.up * (wandLength / 2 + 0.1f), wand.transform.rotation * wand_quat);
        if (CastSound != null)
        {
            AudioSource.PlayClipAtPoint(CastSound, instance.transform.position, 0.5f);
        }
        else
        {
            Debug.Log("You forgot to attach a Casting sound to SpellControl!");
        }
    }

    void ActivateEarth()
    {
        WandColor.updateColor("Earth");
        if (instance == null)
        {
            instance = Instantiate(earth, Vector3.up * -2.1f, Quaternion.identity);
            instance.GetComponent<Rigidbody>().detectCollisions = false;
        }
        Quaternion wand_quat = Quaternion.Euler(new Vector3(-30.0f, 0, 0));
        Ray aim = new Ray(wand.transform.position, wand.transform.rotation * wand_quat * transform.forward);
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        float enter = 0.0f;
        if (ground.Raycast(aim, out enter))
        {
            Vector3 hitPoint = aim.GetPoint(enter);
            if (Vector3.Distance(hitPoint, new Vector3(wand.transform.position.x, 0, wand.transform.position.z)) > 2)
            {
                instance.transform.position = new Vector3(hitPoint.x, 2, hitPoint.z);
            } else
            {
                Vector3 wandAngle = new Vector3(0, wand.transform.rotation.eulerAngles.y, 0);
                Ray outward = new Ray(new Vector3(wand.transform.position.x, 0, wand.transform.position.z), Quaternion.Euler(wandAngle) * transform.forward);
                hitPoint = outward.GetPoint(2);
                instance.transform.position = new Vector3(hitPoint.x, 2, hitPoint.z);
            }
        }
    }

    void CastEarth()
    {
        WandColor.updateColor("");
        instance.GetComponent<Rigidbody>().detectCollisions = true;
        instance.SendMessage("Cast");
        instance = null;
        if (CastSound != null)
        {
            AudioSource.PlayClipAtPoint(CastSound, instance.transform.position, 0.5f);
        }
        else
        {
            Debug.Log("You forgot to attach a Casting sound to SpellControl!");
        }
    }

    void ActivateFreezing()
    {
        WandColor.updateColor("Freezing");
    }

    void CastFreezing()
    {
        WandColor.updateColor("");
        Quaternion wand_quat = Quaternion.Euler(new Vector3(-30.0f, 0, 0));
        GameObject instance = Instantiate(ice, wand.transform.position + wand.transform.up * (wandLength / 2 + 0.1f), wand.transform.rotation * wand_quat);
        if (CastSound != null)
        {
            AudioSource.PlayClipAtPoint(CastSound, instance.transform.position, 0.5f);
        }
        else
        {
            Debug.Log("You forgot to attach a Casting sound to SpellControl!");
        }
    }

    void ActivateLightning()
    {
        WandColor.updateColor("Lightning");
        if (instance == null)
        {
            instance = Instantiate(lightningLine, wand.transform.position, Quaternion.identity);
            instance.GetComponent<LineRenderer>().material.color = new Color(1, 1, 0, 0.1f);
        }
        UpdateLightningLine();
    }

    void CastLightning()
    {
        WandColor.updateColor("");
        instance.GetComponent<LineRenderer>().material.color = new Color(1, 1, 0, 1);
        InvokeRepeating("InstantiateLightning", 0.0f, 0.15f);
        InvokeRepeating("UpdateLightningLine", 0.0f, 0.01f);
        Invoke("EndLightning", 3.0f);
        if (CastSound != null)
        {
            AudioSource.PlayClipAtPoint(CastSound, instance.transform.position, 0.5f);
        }
        else
        {
            Debug.Log("You forgot to attach a Casting sound to SpellControl!");
        }
    }

    void UpdateLightningLine()
    {
        Quaternion wand_quat = Quaternion.Euler(new Vector3(-30.0f, 0, 0));
        Ray ray = new Ray(wand.transform.position + wand.transform.up * (wandLength / 2 + 0.1f), wand.transform.rotation * wand_quat * transform.forward);
        Vector3 endPoint = ray.GetPoint(50.0f);
        Vector3[] positions = new Vector3[] { wand.transform.position + wand.transform.up * (wandLength / 2 + 0.1f), endPoint };
        instance.GetComponent<LineRenderer>().SetPositions(positions);
    }

    void InstantiateLightning()
    {
        Quaternion wand_quat = Quaternion.Euler(new Vector3(-30.0f, 0, 0));
        GameObject bolt = Instantiate(lightning, wand.transform.position + wand.transform.up * (wandLength / 2 + 0.1f), wand.transform.rotation * wand_quat);
    }

    void EndLightning()
    {
        CancelInvoke();
        Destroy(instance);
        instance = null;
    }

    void ActivateShield()
    {
        if (mana >= 5)
        {
            shield.transform.SendMessage("Activate");
            mana -= 5;
        }
    }

    void CastShield()
    {
        shield.transform.SendMessage("Cast");
    }
}
