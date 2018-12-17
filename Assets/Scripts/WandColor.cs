using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WandColor : MonoBehaviour {

    static Light halo;
    static Color color = Color.cyan;
    void Start()
    {
        halo = this.gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void updateColor(string spell)
    {
        switch (spell)
        {
            case "Air":
                color = Color.white;
                break;
            case "Fireball":
                color = Color.red;
                break;
            case "Earth":
                color = new Color(222f, 184f, 135f);
                break;
            case "Ice":
                color = Color.blue;
                break;
            case "Shield":
                color = Color.green;
                break;
            case "Lightning":
                color = Color.yellow;
                break;
            default:
                color = Color.cyan;
                break;
        }
        halo.color = color;
    }

    public static void updateIntensity(float manaPercent)
    {
        halo.intensity = Mathf.Pow(manaPercent, 2);
        //Debug.Log(halo.intensity);
    }
}
