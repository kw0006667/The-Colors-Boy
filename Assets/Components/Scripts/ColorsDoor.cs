using UnityEngine;
using System.Collections;

public class ColorsDoor : MonoBehaviour
{
    public GameDefine.RGBColors CurrentColor;

    private GameObject man;
    private Color man_color;
    private Color door_color;

    // Use this for initialization
    void Start()
    {
        this.man = GameObject.FindWithTag("Player");
        this.man_color = this.man.GetComponentInChildren<Renderer>().material.GetColor("_Color");

        switch (this.CurrentColor)
        {
            case GameDefine.RGBColors.Red:
                this.door_color = new Color(1.0f, 0.0f, 0.0f, 0.5f);
                break;
            case GameDefine.RGBColors.Green:
                this.door_color = new Color(0.0f, 1.0f, 0.0f, 0.5f);
                break;
            case GameDefine.RGBColors.Blue:
                this.door_color = new Color(0.0f, 0.0f, 1.0f, 0.5f);
                break;
            case GameDefine.RGBColors.White:
                this.door_color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
                break;
            default:
                break;
        }

        Renderer mat = gameObject.GetComponentsInChildren<Renderer>()[0];
        mat.material.SetColor("_Color", this.door_color);
    }

    // Update is called once per frame
    void Update()
    {
        this.man_color = this.man.GetComponentInChildren<Renderer>().material.GetColor("_Color");
        if (Compare.Color3(this.man_color, this.door_color))
            this.collider.enabled = false;
        else
            this.collider.enabled = true;
    }
}
