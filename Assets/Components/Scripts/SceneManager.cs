using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        if (Input.GetJoystickNames().Length > 0)
            print(Input.GetJoystickNames()[0]);
        else
            print("No Input.");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Start"))
            print("Start");

        if (Input.GetButtonDown("Back"))
            print("Back");
    }
}
