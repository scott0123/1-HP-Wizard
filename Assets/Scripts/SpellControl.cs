using UnityEngine;
using System.Collections;

public class SpellControl : MonoBehaviour {

    public AudioClip castSound;
    public GameObject spell;
    public GameObject fireball;
    public GameObject earth;
    public GameObject ice;
    public GameObject air;
    public GameObject lightning;
    public GameObject wand;
    public GameObject shield;

	private float wandLength;
    private int mana;

    private string primedSpell = "";

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

    //void checkGestures()
    //{
    //if a gesture succeeds, set primedSpell to the capitalized string of that spell such as "Air"
    //primedSpell = selectedSpell;
    //}

    void DetectTrigger()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))// && primedSpell != "") // this might need changing, Button.PrimaryThumbStick
        {
            Invoke("Cast" + primedSpell, 0.0f);
            primedSpell = "";
        }
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)) // this might need changing, Button.PrimaryThumbStick
        {
            primedSpell = "Air";
            //CastAir();
        }
        else if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            primedSpell = "Lightning";
            //CastLightning();
        }
        else if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick))
        {
            CastSpell();
        }
        else if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick))
        {
            primedSpell = "Shield";
            //print("shield");
            //CastShield();
        }

    }
    
	void CastSpell() {
        if (mana >= 1)
        {
            Quaternion wand_quat = Quaternion.Euler(new Vector3(-30.0f, 0, 0));
            GameObject instance = Instantiate(spell, wand.transform.position + wand.transform.up * (wandLength / 2 + 0.1f), wand.transform.rotation * wand_quat);
            if (castSound != null)
            {
                AudioSource.PlayClipAtPoint(castSound, instance.transform.position, 0.5f);
            }
            else
            {
                Debug.Log("You forgot to attach a casting sound to SpellControl!");
            }

            mana--;
        }
    }

    void CastAir()
    {
        Quaternion wand_quat = Quaternion.Euler(new Vector3(-30.0f, 0, 0));
        GameObject instance = Instantiate(air, wand.transform.position + wand.transform.up * (wandLength / 2 + 0.1f) + wand.transform.forward * 3, wand.transform.rotation * wand_quat);
        if (castSound != null)
        {
            AudioSource.PlayClipAtPoint(castSound, instance.transform.position, 0.5f);
        }
        else
        {
            Debug.Log("You forgot to attach a casting sound to SpellControl!");
        }
    }

    void CastFireball()
    {
        if (mana >= 5)
        {
            Quaternion wand_quat = Quaternion.Euler(new Vector3(-30.0f, 0, 0));
            GameObject instance = Instantiate(fireball, wand.transform.position + wand.transform.up * (wandLength / 2 + 0.1f), wand.transform.rotation * wand_quat);
            if (castSound != null)
            {
                AudioSource.PlayClipAtPoint(castSound, instance.transform.position, 0.5f);
            }
            else
            {
                Debug.Log("You forgot to attach a casting sound to SpellControl!");
            }

            mana -= 5;
        }
    }

    void CastEarth()
    {
        Quaternion wand_quat = Quaternion.Euler(new Vector3(-30.0f, 0, 0));
        GameObject instance = Instantiate(earth, wand.transform.position + wand.transform.up * (wandLength / 2 + 0.1f), wand.transform.rotation * wand_quat);
        if (castSound != null)
        {
            AudioSource.PlayClipAtPoint(castSound, instance.transform.position, 0.5f);
        }
        else
        {
            Debug.Log("You forgot to attach a casting sound to SpellControl!");
        }
    }

    void CastIce()
    {
        Quaternion wand_quat = Quaternion.Euler(new Vector3(-30.0f, 0, 0));
        GameObject instance = Instantiate(ice, wand.transform.position + wand.transform.up * (wandLength / 2 + 0.1f), wand.transform.rotation * wand_quat);
        if (castSound != null)
        {
            AudioSource.PlayClipAtPoint(castSound, instance.transform.position, 0.5f);
        }
        else
        {
            Debug.Log("You forgot to attach a casting sound to SpellControl!");
        }
    }

    void CastLightning()
    {
        if (mana >= 10)
        {
            Quaternion wand_quat = Quaternion.Euler(new Vector3(-30.0f, 0, 0));
            GameObject instance = Instantiate(lightning, wand.transform.position + wand.transform.up * (wandLength / 2 + 0.1f), wand.transform.rotation * wand_quat);
            instance.transform.SetParent(wand.transform);
            if (castSound != null)
            {
                AudioSource.PlayClipAtPoint(castSound, instance.transform.position, 0.5f);
            }
            else
            {
                Debug.Log("You forgot to attach a casting sound to SpellControl!");
            }

            mana -= 10;
        }
    }

    void CastShield()
    {
        if (mana >= 5)
        {
            shield.transform.SendMessage("ActivateShield");
            mana -= 5;
        }
    }
}
