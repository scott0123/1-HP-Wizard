﻿using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;

public class SpellControl : MonoBehaviour {

    public AudioClip CastSound;
    public GameObject spell;
    public GameObject fireball;
    public GameObject earth;
    public GameObject earthAim;
    public GameObject ice;
    public GameObject air;
    public GameObject lightning;
    public GameObject lightningVisual;
    public GameObject wandTip;
    public GameObject shield;
    public GameObject lightningLine;
    public GameObject aimLine;
    public GameObject groundPlane;

    public Text optionalUI;

    GameObject instance;
    GameObject aimRay;
    

    public string primedSpell;
    
    private int mana;


    private double manaRegenInterval;
    private double manaRegenTimer;

    void Start(){
        mana = 20;

        instance = null;
        aimRay = Instantiate(aimLine, wandTip.transform.position, Quaternion.identity);
        aimRay.GetComponent<LineRenderer>().material.color = new Color(1, 1, 1, 0.1f);

        primedSpell = "";

        manaRegenInterval = 1.0f;
        manaRegenTimer = 1.0f;
    }
    void Update() {
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0)
        {
            if (aimRay && aimRay.activeSelf)
                aimRay.SetActive(false);
        }
        else
        {
            if (aimRay && !aimRay.activeSelf)
                aimRay.SetActive(true);
        }

        if (optionalUI != null)
        {
            optionalUI.text = "Mana: " + mana;
        }
        manaRegenTimer -= Time.deltaTime;
        if (manaRegenTimer <= 0.0f)
        {
            if (mana < 20)
            {
                mana++;
                WandColor.updateIntensity(mana / 20.0f);
            }
            manaRegenTimer = manaRegenInterval;
        }
        DetectTrigger();

        if (aimRay)
            UpdateAimLine();
    }

    void DetectTrigger()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            primedSpell = "";
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

    void UpdateAimLine()
    {
        Quaternion wand_quat = Quaternion.Euler(new Vector3(-30.0f, 0, 0));
        Ray ray = new Ray(wandTip.transform.position, wandTip.transform.rotation * wand_quat * transform.forward);
        Vector3 endPoint = ray.GetPoint(50.0f);
        Vector3[] positions = new Vector3[] { wandTip.transform.position, endPoint };
        aimRay.GetComponent<LineRenderer>().SetPositions(positions);
    }

    void CastSpell() {
        if (mana >= 1)
        {
            Quaternion wand_quat = Quaternion.Euler(new Vector3(-30.0f, 0, 0));
            Quaternion prefab_offset = Quaternion.Euler(new Vector3(0, 0, 90.0f));
            GameObject instance = Instantiate(spell, wandTip.transform.position, wandTip.transform.rotation * wand_quat * prefab_offset);
            if (CastSound != null)
            {
                AudioSource.PlayClipAtPoint(CastSound, instance.transform.position, 0.5f);
            }
            else
            {
                Debug.Log("You forgot to attach a Casting sound to SpellControl!");
            }

            mana--;
            WandColor.updateIntensity(mana / 20.0f);
        }
    }

    void ActivateAir()
    {
        WandColor.updateColor("Air");
        Vector3 wandAngle = new Vector3(wandTip.transform.rotation.eulerAngles.x - 30.0f, wandTip.transform.rotation.eulerAngles.y, 0);
        Quaternion direction = Quaternion.Euler(wandAngle);
        Ray ray = new Ray(wandTip.transform.position, Quaternion.Euler(wandAngle) * transform.forward);
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

            primedSpell = "";

            mana -= 5;
            WandColor.updateIntensity(mana / 20.0f);
        }
    }

    void ActivateFireball()
    {
        WandColor.updateColor("Fireball");
    }

    void CastFireball()
    {
        if (mana >= 5)
        {
            WandColor.updateColor("");
            Quaternion wand_quat = Quaternion.Euler(new Vector3(-30.0f, 0, 0));
            GameObject instance = Instantiate(fireball, wandTip.transform.position + wand_quat * wandTip.transform.forward, wandTip.transform.rotation * wand_quat);
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
            WandColor.updateIntensity(mana / 20.0f);
        }
    }

    void ActivateEarth()
    {
        WandColor.updateColor("Earth");
        if (instance == null)
        {
            instance = Instantiate(earthAim, Vector3.up * -2.1f, Quaternion.identity);
            Color color = instance.GetComponent<Renderer>().material.color;
            instance.GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, 0.1f);
        }
        Quaternion wand_quat = Quaternion.Euler(new Vector3(-30.0f, 0, 0));
        Ray aim = new Ray(wandTip.transform.position, wandTip.transform.rotation * wand_quat * transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(aim, out hit) && hit.collider.gameObject.tag == "Ground")
        {
            if (Vector3.Distance(hit.point, wandTip.transform.position) > 2)
            {
                instance.transform.position = new Vector3(hit.point.x, hit.point.y + 2, hit.point.z);
            }
            else
            {
                Vector3 wandAngle = new Vector3(0, wandTip.transform.rotation.eulerAngles.y, 0);
                Ray outward = new Ray(new Vector3(wandTip.transform.position.x, 0, wandTip.transform.position.z), Quaternion.Euler(wandAngle) * transform.forward);
                Vector3 hitPoint = outward.GetPoint(2);
                instance.transform.position = new Vector3(hitPoint.x, hitPoint.y + 2, hitPoint.z);
            }
           }
    }

    void CastEarth()
    { 
        if (mana >= 10)
        {
            WandColor.updateColor("");
            GameObject earthObject = Instantiate(earth, instance.transform.position + Vector3.down * 4.1f, Quaternion.identity);
            Destroy(instance);
            instance = null;

            primedSpell = "";

            mana -= 10;
            WandColor.updateIntensity(mana / 20.0f);
        }
    }

    void ActivateIce()
    {
        WandColor.updateColor("Ice");
    }

    void CastIce()
    {
        if (mana >= 5)
        {
            WandColor.updateColor("");
            Quaternion wand_quat = Quaternion.Euler(new Vector3(-30.0f, 0, 0));
            Quaternion ice_offset = Quaternion.Euler(new Vector3(90.0f, 0, 0));
            GameObject instance = Instantiate(ice, wandTip.transform.position + wand_quat * wandTip.transform.forward, wandTip.transform.rotation * wand_quat * ice_offset);
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
            WandColor.updateIntensity(mana / 20.0f);
        }
    }

    void ActivateLightning()
    {
        WandColor.updateColor("Lightning");
    }

    void CastLightning()
    {
        if (mana >= 10)
        {
            WandColor.updateColor("");
            Quaternion wand_quat = Quaternion.Euler(new Vector3(-120.0f, 0, 0));
            InvokeRepeating("InstantiateLightning", 0.0f, 0.3f);
            Invoke("EndLightning", 3.0f);

            primedSpell = "";

            mana -= 10;
            WandColor.updateIntensity(mana / 20.0f);
        }
    }

    void UpdateLightningVisual()
    {
        Quaternion wand_quat = Quaternion.Euler(new Vector3(-120.0f, 0, 0));
        instance.transform.position = wandTip.transform.position;
        instance.transform.rotation = wandTip.transform.rotation * wand_quat;
    }

    void InstantiateLightning()
    {
        Quaternion wand_quat = Quaternion.Euler(new Vector3(-30.0f, 0, 0));
        Quaternion visual_offset = Quaternion.Euler(new Vector3(-90.0f, 0, 0));
        instance = Instantiate(lightningVisual, wandTip.transform.position, wandTip.transform.rotation * wand_quat * visual_offset);
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
        shield.transform.SendMessage("Activate");
    }

    void CastShield()
    {
        if (mana >= 5)
        {
            shield.transform.SendMessage("Cast");

            primedSpell = "";

            mana -= 5;
            WandColor.updateIntensity(mana / 20.0f);
        }
    }
}
