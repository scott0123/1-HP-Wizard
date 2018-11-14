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

	void Start(){
		
		wandLength = 0.15f;
	}
	void Update(){
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
		Quaternion wand_quat = Quaternion.Euler (new Vector3(-30.0f, 0, 0));
		GameObject instance = Instantiate(spell, wand.transform.position + wand.transform.up * (wandLength / 2 + 0.1f), wand.transform.rotation * wand_quat);
		if (castSound != null) {
			AudioSource.PlayClipAtPoint (castSound, instance.transform.position, 0.5f);
		} else {
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

    void CastLightning()
    {
        Quaternion wand_quat = Quaternion.Euler(new Vector3(-30.0f, 0, 0));
        GameObject instance = Instantiate(lightning, wand.transform.position + wand.transform.up * (wandLength / 2 + 0.1f), wand.transform.rotation * wand_quat);
        Transform right_hand = this.transform.Find("LocalAvatar/hand_right");
        instance.transform.SetParent(right_hand);
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
