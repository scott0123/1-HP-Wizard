using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class GestureCollector : MonoBehaviour {

    public Transform wandTip;
    public string label;

    private List<float> x = new List<float>();
    private List<float> y = new List<float>();
    private List<float> z = new List<float>();
    private List<NamedGesture> data = new List<NamedGesture>();
    private bool collecting = false;
    private Vector3 gestureStartingPosition;
    private Quaternion gestureStartingRotation;

    void Start() {
        collecting = false;
    }

    void Update() {
        
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0) { // Right, Side-button
            Collect();
        } else {
            collecting = false;
        }
        
        if (OVRInput.GetDown(OVRInput.Button.One)) { // Right, A
            Debug.Log("Labeled True");
            LabelTrue();
        }
        if (OVRInput.GetDown(OVRInput.Button.Two)) { // Right, B
            Debug.Log("Labeled False");
            LabelFalse();
        }
        if (OVRInput.GetDown(OVRInput.Button.Three)) { // Left, X
            Debug.Log("Saving");
            Save();
        }
    }

    void Collect() {
        if (!collecting) {
            Debug.Log("Started collecting");
            collecting = true;
            gestureStartingPosition = wandTip.position;
            gestureStartingRotation = wandTip.rotation;
            x.Clear();
            y.Clear();
            z.Clear();
        }
        //temporary solution -- data points relative to wandTip rotation
        Vector3 dataVect = wandTip.position - gestureStartingPosition;
        dataVect = Quaternion.Inverse(gestureStartingRotation) * dataVect;
        x.Add(dataVect.x);
        y.Add(dataVect.y);
        z.Add(dataVect.z);
        /*x.Add(wandTip.position.x - gestureStartingPosition.x);
        y.Add(wandTip.position.y - gestureStartingPosition.y);
        z.Add(wandTip.position.z - gestureStartingPosition.z);*/
    }

    void LabelTrue() {
        NamedGesture ng = new NamedGesture();
        ng.name = label;
        ng.gesture = new List<List<float>>();
        ng.gesture.Add(new List<float>(x.ToArray()));
        ng.gesture.Add(new List<float>(y.ToArray()));
        ng.gesture.Add(new List<float>(z.ToArray()));
        data.Add(ng);
    }
    void LabelFalse() {
        NamedGesture ng = new NamedGesture();
        ng.name = "!";
        ng.name += label;
        ng.gesture = new List<List<float>>();
        ng.gesture.Add(new List<float>(x.ToArray()));
        ng.gesture.Add(new List<float>(y.ToArray()));
        ng.gesture.Add(new List<float>(z.ToArray()));
        data.Add(ng);
    }
    void Save() {

        string saveString1 = "";
        string saveString2 = "";
        for(int i = 0; i < data.Count; i++){
            string name = data[i].name;
            if (name[0] == '!') {
                if(saveString2.Length != 0) saveString2 += "\n";
                saveString2 += NamedGestureToJson(data[i]);
            } else {
                if(saveString1.Length != 0) saveString1 += "\n";
                saveString1 += NamedGestureToJson(data[i]);
            }
        }
        string path1 = "Assets/Output/";
        path1 += label;
        path1 += ".ndjson";
        string path2 = "Assets/Output/";
        path2 += "!";
        path2 += label;
        path2 += ".ndjson";
        StreamWriter writer1 = new StreamWriter(path1, true);
        writer1.Write(saveString1);
        writer1.Close();
        StreamWriter writer2 = new StreamWriter(path2, true);
        writer2.Write(saveString2);
        writer2.Close();
        Debug.Log("Finished Saving");
    }

    string NamedGestureToJson(NamedGesture ng) {
        string s = "{\"name\":\"";
        s += ng.name;
        s += "\",\"gesture\":[";
        string gs = ""; // gesture string
        foreach (List<float> fl in ng.gesture) {
            if (gs.Length != 0) gs += ",";
            string fs = "["; // float list string
            foreach (float f in fl) {
                if (fs.Length != 1) fs += ",";
                fs += f.ToString("F4");
            }
            gs += fs + "]";
        }
        s += gs;
        s += "]}";
        return s;
    }
}

[Serializable]
public class NamedGesture {
    public string name;
    public List<List<float>> gesture;
}
