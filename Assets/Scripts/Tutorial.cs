using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Oculus;

public class Tutorial : MonoBehaviour {

    public GameObject dummy;
    public Text tutorialText;
    public Text continueText;
    public Image tutorialImage;

    public Sprite fireball;
    public Sprite lightning;
    public Sprite earth;
    public Sprite ice;
    public Sprite air;
    public Sprite shield;

    string text0 = "Welcome to 1HP Wizard!"; // 0
    string text1 = "Learn to cast spells to defeat your enemies on this exciting journey. \r\n \r\nBut be careful! You only have one life. #yolo"; // 1
    string text2 = "To cast a spell, hold down the button your right middle finger is on while tracing the spell gesture with your wand. \r\n \r\nPress the button your right index finger is on when you're ready to shoot."; // 2
    string text3 = "Your magic regenerates but it is limited so choose your spells wisely! \r\n \r\nThe wand glows to indicate how much magic you have"; // 3
    string text4 = "Let's practice our spells now!"; // 4
    string text5 = "Point and shoot: low cost, low damage. \r\n No gesture, just press the button with your right index finger."; // 5
    string text6 = "Fireball: medium cost, offensive spell";
    string text7 = "Lightning: high cost, offensive spell";
    string text8 = "Earth: medium cost, utility spell";
    string text9 = "Ice: medium cost, utility spell";
    string text10 = "Air: medium cost, defensive spell";
    string text11 = "Shield: medium cost, defensive spell";
    string text12 = "Congratulations! You've passed the tutorial.";
    string text13 = "";
    string text14 = "";
    string text15 = "";

    string continueTextContent = "Press A to continue";

    public int stage;

    // Use this for initialization
    void Start () {

        stage = 0;
        tutorialText.text = text0;
        tutorialImage.enabled = false;
        continueText.text = continueTextContent;
        continueText.enabled = true;
        dummy.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.GetDown(OVRInput.Button.One)) // A
        {
            if (stage >= 5 && stage <= 11) // spell stages
            {
                return;
            }
            NextStage();
        }
	}

    void NextStage()
    {
        stage++;
        switch (stage)
        {
            case 1:
                tutorialText.text = text1;
                break;
            case 2:
                tutorialText.text = text2;
                break;
            case 3:
                tutorialText.text = text3;
                break;
            case 4:
                tutorialText.text = text4;
                break;
            case 5:
                continueText.enabled = false;
                dummy.SetActive(true);
                tutorialText.text = text5;
                break;
            case 6:
                tutorialText.text = text6;
                tutorialImage.enabled = true;
                tutorialImage.sprite = fireball;
                break;
            case 7:
                tutorialText.text = text7;
                tutorialImage.sprite = lightning;
                break;
            case 8:
                tutorialText.text = text8;
                tutorialImage.sprite = earth;
                break;
            case 9:
                tutorialText.text = text9;
                tutorialImage.sprite = ice;
                break;
            case 10:
                tutorialText.text = text10;
                tutorialImage.sprite = air;
                break;
            case 11:
                tutorialText.text = text11;
                tutorialImage.sprite = shield;
                break;
            case 12:
                dummy.SetActive(false);
                continueText.enabled = true;
                tutorialText.text = text12;
                tutorialImage.enabled = false;
                break;
            case 13:
                tutorialText.text = text13;
                break;
            default:
                // TODO: move on to the game
                break;
        }
    }
}
