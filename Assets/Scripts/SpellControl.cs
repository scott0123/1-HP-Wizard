using UnityEngine;
using UnityEngine.UI;
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
    public GameObject wandTip;
    public GameObject shield;
    public GameObject lightningLine;

    public Text optionalUI;

    GameObject instance;
    

    public string primedSpell;
    
    private int mana;


    private double manaRegenInterval;
    private double manaRegenTimer;

    void Start(){
        mana = 20;

        instance = null;
        primedSpell = "";

        manaRegenInterval = 1.0f;
        manaRegenTimer = 1.0f;
    }
    void Update() {
        if (optionalUI != null)
        {
            optionalUI.text = "Mana: " + mana;
        }
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
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            primedSpell = "";
            if (instance)
                EndLightning();
            WandColor.updateColor("");
        }

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            if (primedSpell != "")
            {
                Invoke("Cast" + primedSpell, 0.0f);
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
            GameObject instance = Instantiate(spell, wandTip.transform.position, wandTip.transform.rotation * wand_quat);
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
        Invoke("EndLightning", 0.01f);
        WandColor.updateColor("Air");
        Vector3 wandAngle = new Vector3(0, wandTip.transform.rotation.eulerAngles.y, 0);
        Quaternion direction = Quaternion.Euler(wandAngle);
        Ray ray = new Ray(new Vector3(wandTip.transform.position.x, 2, wandTip.transform.position.z), Quaternion.Euler(wandAngle) * transform.forward);
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
        if (mana >= 5)
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

            primedSpell = "";

            mana -= 5;
        }
    }

    void ActivateFireball()
    {
        Invoke("EndLightning", 0.01f);
        WandColor.updateColor("Fireball");
        wandTip.GetComponent<WandColor>().SendMessage("updateColor", "Fireball");
    }

    void CastFireball()
    {
        if (mana >= 5)
        {
            WandColor.updateColor("");
            Quaternion wand_quat = Quaternion.Euler(new Vector3(-30.0f, 0, 0));
            GameObject instance = Instantiate(fireball, wandTip.transform.position, wandTip.transform.rotation * wand_quat);
            if (CastSound != null)
            {
                AudioSource.PlayClipAtPoint(CastSound, instance.transform.position, 0.5f);
            }
            else
            {
                Debug.Log("You forgot to attach a Casting sound to SpellControl!");
            }

            primedSpell = "";

            mana -= 5;
        }
    }

    void ActivateEarth()
    {
        Invoke("EndLightning", 0.01f);
        WandColor.updateColor("Earth");
        if (instance == null)
        {
            instance = Instantiate(earth, Vector3.up * -2.1f, Quaternion.identity);
            instance.GetComponent<Rigidbody>().detectCollisions = false;
            instance.GetComponent<CapsuleCollider>().enabled = false;
        }
        Quaternion wand_quat = Quaternion.Euler(new Vector3(-30.0f, 0, 0));
        Ray aim = new Ray(wandTip.transform.position, wandTip.transform.rotation * wand_quat * transform.forward);
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        float enter = 0.0f;
        if (ground.Raycast(aim, out enter))
        {
            Vector3 hitPoint = aim.GetPoint(enter);
            if (Vector3.Distance(hitPoint, new Vector3(wandTip.transform.position.x, 0, wandTip.transform.position.z)) > 2)
            {
                instance.transform.position = new Vector3(hitPoint.x, 2, hitPoint.z);
            } else
            {
                Vector3 wandAngle = new Vector3(0, wandTip.transform.rotation.eulerAngles.y, 0);
                Ray outward = new Ray(new Vector3(wandTip.transform.position.x, 0, wandTip.transform.position.z), Quaternion.Euler(wandAngle) * transform.forward);
                hitPoint = outward.GetPoint(2);
                instance.transform.position = new Vector3(hitPoint.x, 2, hitPoint.z);
            }
        }
    }

    void CastEarth()
    { 
        if (mana >= 10)
        {
            WandColor.updateColor("");
            instance.GetComponent<CapsuleCollider>().enabled = true;
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

            primedSpell = "";

            mana -= 10;
        }
    }

    void ActivateIce()
    {
        EndLightning();
        WandColor.updateColor("Ice");
    }

    void CastIce()
    {
        if (mana >= 5)
        {
            WandColor.updateColor("");
            Quaternion wand_quat = Quaternion.Euler(new Vector3(-30.0f, 0, 0));
            GameObject instance = Instantiate(ice, wandTip.transform.position, wandTip.transform.rotation * wand_quat);
            if (CastSound != null)
            {
                AudioSource.PlayClipAtPoint(CastSound, instance.transform.position, 0.5f);
            }
            else
            {
                Debug.Log("You forgot to attach a Casting sound to SpellControl!");
            }

            primedSpell = "";

            mana -= 5;
        }
    }

    void ActivateLightning()
    {
        WandColor.updateColor("Lightning");
        if (instance == null)
        {
            instance = Instantiate(lightningLine, wandTip.transform.position, Quaternion.identity);
            instance.GetComponent<LineRenderer>().material.color = new Color(1, 1, 0, 0.1f);
        }
        UpdateLightningLine();
    }

    void CastLightning()
    {
        if (mana >= 10)
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

            primedSpell = "";

            mana -= 10;
        }
    }

    void UpdateLightningLine()
    {
        Quaternion wand_quat = Quaternion.Euler(new Vector3(-30.0f, 0, 0));
        Ray ray = new Ray(wandTip.transform.position, wandTip.transform.rotation * wand_quat * transform.forward);
        Vector3 endPoint = ray.GetPoint(50.0f);
        Vector3[] positions = new Vector3[] { wandTip.transform.position, endPoint };
        instance.GetComponent<LineRenderer>().SetPositions(positions);
    }

    void InstantiateLightning()
    {
        Quaternion wand_quat = Quaternion.Euler(new Vector3(-30.0f, 0, 0));
        GameObject bolt = Instantiate(lightning, wandTip.transform.position, wandTip.transform.rotation * wand_quat);
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

            primedSpell = "";
            mana -= 5;
        }
    }

    void CastShield()
    {
        shield.transform.SendMessage("Cast");
    }
}
