using UnityEngine;
using System.Collections;

public class TutorialMission : MonoBehaviour
{
    public GameDefine.ScenesName CurrentScene;
    public GameObject[] Targets;

    private bool isInTargetArea;

    private float totalTime;

    // Use this for initialization
    void Start()
    {
        this.isInTargetArea = false;
        this.totalTime = 0.0f;
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
                            Application.LoadLevel(GameDefine.TUTORIALSCENE_2);
                        }
                    }
                    break;
                case GameDefine.ScenesName.TutorialScene_2:
                    this.totalTime += Time.deltaTime;
                    if (this.totalTime >= 3.0f)
                        Application.LoadLevel(GameDefine.TUTORIALSCENE_3);
                    break;
                case GameDefine.ScenesName.TutorialScene_3:
                    this.totalTime += Time.deltaTime;
                    if (this.totalTime >= 2.0f)
                        Application.LoadLevel("3_Scene");
                    break;
                default:
                    break;
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
