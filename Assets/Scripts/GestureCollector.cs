using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GestureCollector : MonoBehaviour {

    public Transform wand;
    public string label;

    private List<float> x = new List<float>();
    private List<float> y = new List<float>();
    private List<float> z = new List<float>();
    private List<NamedGesture> data = new List<NamedGesture>
    private bool collecting = false;
    private Vector3 gestureStartingPosition;

    void Start() {
        collecting = false;
    }

    void Update() {

        if (Input.GetButtonDown("RightSide")) {
            Collect();
        } else {
            collecting = false;
        }
        
        if (Input.GetButtonDown("X")) {
            LabelTrue();
        }
        if (Input.GetButtonDown("Y")) {
            LabelFalse();
        }
        if (Input.GetButtonDown("Z")) {
            Save();
        }
    }

    void Collect() {
        if (!collecting) {
            collecting = true;
            gestureStartingPosition = wand.position;
            x.Clear();
            y.Clear();
        }
        x.Add(wand.position.x - gestureStartingPosition.x)
        y.Add(wand.position.y - gestureStartingPosition.y)
        z.Add(wand.position.z - gestureStartingPosition.z)
    }

    void LabelTrue() {
        NamedGesture ng = new NamedGesture();
        ng.name = label;
        ng.gesture = new List<List<float>>();
        ng.gesture.Add(x);
        ng.gesture.Add(y);
        ng.gesture.Add(z);
        data.Add(ng);
    }
    void LabelFalse() {
        NamedGesture ng = new NamedGesture();
        ng.name = "!";
        ns.name += label;
        ng.gesture = new List<List<float>>();
        ng.gesture.Add(x);
        ng.gesture.Add(y);
        ng.gesture.Add(z);
        data.Add(ng);
    }
    void Save() {
        string saveString1 = "";
        string saveString2 = "";
        for(int i = 0; i < data.Count; i++){
            string name = data[i].name;
            if (name[0] == "!") {
                if(saveString2.Length != 0) saveString2 += "\n";
                saveString2 += JsonUtility.ToJson(data[i]);
            } else {
                if(saveString1.Length != 0) saveString1 += "\n";
                saveString1 += JsonUtility.ToJson(data[i]);
            }
        }
        string path1 = "Assets/Output/"
        path1 += label;
        path1 += ".ndjson";
        string path2 = "Assets/Output/"
        path2 += "!";
        path2 += label;
        path2 += ".ndjson";
        StreamWriter writer1 = new StreamWriter(path1, true);
        writer1.Write(saveString1);
        writer1.Close();
        StreamWriter writer2 = new StreamWriter(path2, true);
        writer2.Write(saveString2);
        writer2.Close();
    }
}

[Serializable]
public class NamedGesture {
    public string name;
    public List<List<float>> gesture;
}
