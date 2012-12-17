using UnityEngine;
using System.Collections;

public class JumpDown_Trigger : MonoBehaviour
{

    // Use this for initialization
    public enum JumpDownDirector
    {
        Left = 1,
        Right = 2
    };

    public JumpDownDirector director = JumpDownDirector.Left;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Verify the Trigger's director is same as the Man
    /// </summary>
    /// <param name="col">Trigger Collider</param>
    /// <returns>If same return true, or not.</returns>
    bool isSameDirector(Collider col)
    {
        int sign;
        float speed = col.GetComponent<Robot>().GetSpeed();
        if (speed > 0)
            sign = 1;
        else if (speed < 0)
            sign = 2;
        else
            sign = 0;

        if ((this.director == JumpDownDirector.Left) && sign == 2)
            return true;
        else if ((this.director == JumpDownDirector.Right) && sign == 1)
            return true;
        else
            return false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag.Equals(GameDefine.PLAYERNAME) && this.isSameDirector(col))
        {
            col.GetComponent<Robot>().SetCanJumpDown(true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag.Equals(GameDefine.PLAYERNAME) || !this.isSameDirector(col))
        {
            col.GetComponent<Robot>().SetCanJumpDown(false);
        }
    }
}
