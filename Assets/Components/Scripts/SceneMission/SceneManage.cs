using UnityEngine;
using System.Collections;

public class SceneManage : MonoBehaviour
{
    public GUISkin guiSkin;

    private Rect TitleRect;

    private bool isStartPressed;
    private bool isBackPressed;

    // Use this for initialization
    void Start()
    {
        if (Input.GetJoystickNames().Length > 0)
            print(Input.GetJoystickNames()[0]);
        else
            print("No Input.");

        this.isStartPressed = false;
        this.isBackPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            print("Start");
            this.isStartPressed = true;
        }
        //print("Is Start Pressed ? " + this.isStartPressed);

        if (Input.GetButtonDown("Back") && !this.isStartPressed && !this.isBackPressed)
        {
            print("Back");
            this.isBackPressed = true;
        }
        print("Is Back Pressed ? " + this.isBackPressed);

        if (this.isBackPressed)
        {
            if (Input.GetButtonDown("Back"))
            {
                if (!Application.isEditor && !Application.isWebPlayer)
                {
                    Application.Quit();
                }
            }
        }

        if (this.isStartPressed)
        {
            if (Input.GetButtonDown("Back"))
            {
                print("Start Canceled!");
                this.isStartPressed = false;
            }

            if (Input.GetButtonDown("Fire1"))
            {
                this.isStartPressed = false;
                Application.LoadLevel(GameDefine.TUTORIALSCENE_1);
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                this.isStartPressed = false;
                Application.LoadLevel(GameDefine.SCENE_1);
            }
            else if (Input.GetButtonDown("Fire3"))
            {
                this.isStartPressed = false;
                Application.LoadLevel(GameDefine.SCENE_2);
            }
        }
    }

    void OnGUI()
    {
        if (this.guiSkin)
        {
            GUI.skin = this.guiSkin;
            float fontSize = Screen.width / 1600.0f * 70;
            //print("fontsize :" + fontSize);
            string titleString = string.Empty;

            switch (Application.loadedLevelName)
            {
                case GameDefine.TUTORIALSCENE_1:
                    titleString = "<size=" + fontSize + ">Tutorial 1</size>";
                    break;
                case GameDefine.TUTORIALSCENE_2:
                    titleString = "<size=" + fontSize + ">Tutorial 2</size>";
                    break;
                case GameDefine.TUTORIALSCENE_3:
                    titleString = "<size=" + fontSize + ">Tutorial 3</size>";
                    break;
                case GameDefine.SCENE_1:
                    titleString = "<size=" + fontSize + ">SECTION 1</size>";
                    break;
                case GameDefine.SCENE_2:
                    titleString = "<size=" + fontSize + ">SECTION 2</size>";
                    break;
                default:
                    break;
            }
            GUI.Label(new Rect(20, 20, 500, 150), titleString);
        }
    }
}
