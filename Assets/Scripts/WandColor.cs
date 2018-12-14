using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WandColor : MonoBehaviour {

    static SerializedObject halo;
    static Color color = Color.cyan;
    void Start () {
        halo = new SerializedObject(this.gameObject.GetComponent("Halo"));
    }
	
	// Update is called once per frame
	void Update () {
        
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
                color = new Color(1, 0.5f, 0);
                break;
            case "Freezing":
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
        halo.FindProperty("m_Color").colorValue = color;
        halo.ApplyModifiedProperties();
    }
}
