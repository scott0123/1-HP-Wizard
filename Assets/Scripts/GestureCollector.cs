using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System;
using UnityEngine.UI;

public class GestureCollector : MonoBehaviour {

    public GameObject player;
    public GameObject wandTip;
    public GameObject ephemeralTrail;
    public GameObject gestureTrail;
    public string label;
    public Text ui;

    private int positive;
    private int negative;

    private List<float> x = new List<float>();
    private List<float> y = new List<float>();
    private List<float> z = new List<float>();
    private List<NamedGesture> data = new List<NamedGesture>();
    private bool collecting = false;
    private Vector3 gestureStartingPosition;
    private Quaternion gestureStartingRotation;

    // cloned trails that we spawn
    private GameObject ephemeralClone;
    private GameObject gestureClone;

    void Start() {
        collecting = false;
        positive = 0;
        negative = 0;
    }

    void Update() {
        
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0) { // Right, Side-button
            Collect();
        } else {
            StopCollecting();
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
            gestureStartingPosition = wandTip.transform.position;
            gestureStartingRotation = wandTip.transform.rotation;
            x.Clear();
            y.Clear();
            z.Clear();
            ephemeralClone = Instantiate(ephemeralTrail, wandTip.transform.position, wandTip.transform.rotation);
            ephemeralClone.transform.parent = wandTip.transform;
            gestureClone = Instantiate(gestureTrail, wandTip.transform.position, wandTip.transform.rotation);
            gestureClone.transform.parent = wandTip.transform;
        }
        //temporary solution -- data points relative to wandTip.transform rotation
        Vector3 dataVect = wandTip.transform.position - gestureStartingPosition;
        dataVect = Quaternion.Inverse(gestureStartingRotation) * dataVect;
        x.Add(dataVect.x);
        y.Add(dataVect.y);
        z.Add(dataVect.z);
        /*x.Add(wandTip.transform.position.x - gestureStartingPosition.x);
        y.Add(wandTip.transform.position.y - gestureStartingPosition.y);
        z.Add(wandTip.transform.position.z - gestureStartingPosition.z);*/
    }

    void StopCollecting()
    {
        if (collecting)
        {
            collecting = false;
            Destroy(ephemeralClone);
            GameObject referenceToGestureClone = gestureClone;
            UnnamedGesture g = new UnnamedGesture();
            g.gesture = new List<List<float>>();
            g.gesture.Add(new List<float>(x.ToArray()));
            g.gesture.Add(new List<float>(y.ToArray()));
            g.gesture.Add(new List<float>(z.ToArray()));

            if (g.gesture[0].Count > 18 && g.gesture[0].Count < 300)
            {
                StartCoroutine(RecognizeGesture(g, referenceToGestureClone));
            }
            else
            {
                Debug.Log("Length of gesture not valid");
                StartCoroutine(DestroyTrail(referenceToGestureClone));
            }
        }
    }
    IEnumerator RecognizeGesture(UnnamedGesture g, GameObject trail)
    {
        // recognize the gesture
        bool recognized = true;
        SpellControl sc = player.GetComponent<SpellControl>();
        // either glow the trail or get rid of it
        TrailRenderer tr = trail.GetComponent<TrailRenderer>();
        tr.emitting = false;
        String recognizedGesture = "";
        String address = "http://gestures.christiaanh.org:5000";
        address += "/?gesture=";
        address += UnnamedGestureToJson(g);
        using (UnityWebRequest www = UnityWebRequest.Get(address))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                recognized = false;
            }
            else
            {
                String response = www.downloadHandler.text;
                String[] tokens = response.Split('\"');
                recognizedGesture = tokens[3];
                Debug.Log(recognizedGesture);
            }
        }
        if (recognized)
        {
            sc.primedSpell = recognizedGesture;
            tr.startColor = new Color(0, 1, 0, 1);
            tr.endColor = new Color(0, 1, 0, 1);
        }
        StartCoroutine(DestroyTrail(trail));
    }
    IEnumerator DestroyTrail(GameObject trail)
    {
        yield return new WaitForSeconds(1.0f);
        TrailRenderer tr = trail.GetComponent<TrailRenderer>();
        float alpha = tr.startColor.a;
        while (alpha > 0.01f)
        {
            alpha -= 0.01f;
            float r = tr.startColor.r;
            float g = tr.startColor.g;
            float b = tr.startColor.b;
            tr.startColor = new Color(r, g, b, alpha);
            tr.endColor = new Color(r, g, b, alpha);
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(trail);
    }

    void LabelTrue() {
        positive += 1;
        NamedGesture ng = new NamedGesture();
        ng.name = label;
        ng.gesture = new List<List<float>>();
        ng.gesture.Add(new List<float>(x.ToArray()));
        ng.gesture.Add(new List<float>(y.ToArray()));
        ng.gesture.Add(new List<float>(z.ToArray()));
        data.Add(ng);
    }
    void LabelFalse() {
        negative += 1;
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

    string NamedGestureToJson(NamedGesture ng)
    {
        string s = "{\"name\":\"";
        s += ng.name;
        s += "\",\"gesture\":[";
        string gs = ""; // gesture string
        foreach (List<float> fl in ng.gesture)
        {
            if (gs.Length != 0) gs += ",";
            string fs = "["; // float list string
            foreach (float f in fl)
            {
                if (fs.Length != 1) fs += ",";
                fs += f.ToString("F4");
            }
            gs += fs + "]";
        }
        s += gs;
        s += "]}";
        return s;
    }
    string UnnamedGestureToJson(UnnamedGesture g)
    {
        string s = "[";
        string gs = ""; // gesture string
        foreach (List<float> fl in g.gesture)
        {
            if (gs.Length != 0) gs += ",";
            string fs = "["; // float list string
            foreach (float f in fl)
            {
                if (fs.Length != 1) fs += ",";
                fs += f.ToString("F4");
            }
            gs += fs + "]";
        }
        s += gs;
        s += "]";
        return s;
    }
}

[Serializable]
public class NamedGesture
{
    public string name;
    public List<List<float>> gesture;
}
public class UnnamedGesture
{
    public List<List<float>> gesture;
}
