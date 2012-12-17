using UnityEngine;
using System.Collections;

public class TutorialMission : MonoBehaviour
{
    public GameDefine.ScenesName CurrentScene;
    public GameObject[] Targets;
    public GUISkin GSkin;

    private bool isInTargetArea;

    private float totalTime;

    private bool isFinishedDemo;

    // Use this for initialization
    void Start()
    {
        this.isInTargetArea = false;
        this.totalTime = 0.0f;
        this.isFinishedDemo = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isInTargetArea)
        {
            switch (this.CurrentScene)
            {
                case GameDefine.ScenesName.TutorialScene_1:
                    Color man_color = GameObject.FindWithTag(GameDefine.PLAYERNAME).GetComponentInChildren<Renderer>().material.GetColor("_Color");
                    Color target_color;
                    if (Targets.Length != 0)
                    {
                        target_color = Targets[0].GetComponentInChildren<Renderer>().material.GetColor("_Color");
                        if (Compare.Color3(man_color, target_color))
                        {
                            this.totalTime += Time.deltaTime;
                            if (this.totalTime >= 2.0f)
                                Application.LoadLevel(GameDefine.TUTORIALSCENE_2);
                        }
                    }
                    break;
                case GameDefine.ScenesName.TutorialScene_2:
                    this.totalTime += Time.deltaTime;
                    if (this.totalTime >= 2.0f)
                        Application.LoadLevel(GameDefine.TUTORIALSCENE_3);
                    break;
                case GameDefine.ScenesName.TutorialScene_3:
                    this.totalTime += Time.deltaTime;
                    if (this.totalTime >= 2.0f)
                        Application.LoadLevel(GameDefine.SCENE_1);
                    break;
                case GameDefine.ScenesName.Scene_3:
                    this.totalTime += Time.deltaTime;
                    if (this.totalTime >= 5.0f)
                        Application.LoadLevel(GameDefine.SCENE_2);
                    break;
                case GameDefine.ScenesName.Scene_4:
                    this.totalTime += Time.deltaTime;
                    if (this.totalTime >= 1.0f)
                        this.isFinishedDemo = true;
                    break;
                default:
                    break;
            }
        }
    }

    void OnGUI()
    {
        if (this.GSkin)
        {
            GUI.skin = this.GSkin;

            if (this.isFinishedDemo)
            {
                float fontSize = Screen.width / 1600.0f * 70;
                //print("fontsize :" + fontSize);
                string titleString = "<size=" + fontSize + ">You Have Finished this <color=yellow>DEMO</color> Version.\n</size><size=" + fontSize * 0.7f +">Thanks for Your Playing!! :)</size>";
                GUI.Label(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 150, 800, 300), titleString);
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag.Equals(GameDefine.PLAYERNAME) && !this.isInTargetArea)
        {
            this.isInTargetArea = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag.Equals(GameDefine.PLAYERNAME))
        {
            this.isInTargetArea = false;
        }
    }
}
