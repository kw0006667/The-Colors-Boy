using UnityEngine;
using System.Collections;

public class ColorSwitch : MonoBehaviour
{
    public GameDefine.RGBColors CurrentColor;
    private Color currentColor;

    // Use this for initialization
    void Start()
    {
        switch (this.CurrentColor)
        {
            case GameDefine.RGBColors.Red:
                this.currentColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                break;
            case GameDefine.RGBColors.Green:
                this.currentColor = new Color(0.0f, 1.0f, 0.0f, 1.0f);
                break;
            case GameDefine.RGBColors.Blue:
                this.currentColor = new Color(0.0f, 0.0f, 1.0f, 1.0f);
                break;
            case GameDefine.RGBColors.White:
                this.currentColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                break;
            default:
                break;
        }

        Renderer mat = gameObject.GetComponentsInChildren<Renderer>()[0];
        mat.material.SetColor("_Color", this.currentColor);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag.Equals("Player"))
        {
            Renderer rend = col.GetComponentsInChildren<Renderer>()[0];
            rend.material.SetColor("_Color", this.currentColor);
        }
    }
}
