using UnityEngine;
using System.Collections;

public class SpellControl : MonoBehaviour {

	public AudioClip castSound;
    public GameObject spell;
    public GameObject fireball;
    public GameObject lightning;
	public GameObject wand;
    public GameObject shield;

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
		if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)) // this might need changing, Button.PrimaryThumbStick
        { 
			CastLightning();
        } else if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            CastFireball();
        } else if(OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick))
        {
            CastSpell();
        } else if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick))
        {
            print("shield");
            CastShield();
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
