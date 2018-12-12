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

    private string primedSpell = "";

    void Start() {

        wandLength = 0.15f;
    }
    void Update() {
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
		Quaternion wand_quat = Quaternion.Euler (new Vector3(-30.0f, 0, 0));
		GameObject instance = Instantiate(spell, wand.transform.position + wand.transform.up * (wandLength / 2 + 0.1f), wand.transform.rotation * wand_quat);
		if (castSound != null) {
			AudioSource.PlayClipAtPoint (castSound, instance.transform.position, 0.5f);
		} else {
			Debug.Log("You forgot to attach a casting sound to SpellControl!");
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
    }

    void CastShield()
    {
        shield.transform.SendMessage("ActivateShield");
    }
}
