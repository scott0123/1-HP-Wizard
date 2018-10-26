using UnityEngine;
using System.Collections;

public class SpellControl : MonoBehaviour {

	public AudioClip castSound;
    public GameObject spell;
	public GameObject wand;

	private float wandLength;

	void Start(){
		
		wandLength = 0.15f;
	}
	void Update(){
        DetectTrigger();
    }

    void DetectTrigger()
    {
		if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)){ // this might need changing, Button.PrimaryThumbStick
			Cast();
        }
    }
    
	void Cast() {
		Quaternion wand_quat = Quaternion.Euler (new Vector3(-30.0f, 0, 0));
		GameObject instance = Instantiate(spell, wand.transform.position + wand.transform.up * (wandLength / 2 + 0.1f), wand.transform.rotation * wand_quat);
		if (castSound != null) {
			AudioSource.PlayClipAtPoint (castSound, instance.transform.position, 0.5f);
		} else {
			Debug.Log("You forgot to attach a casting sound to SpellControl!");
		}
    }
}
