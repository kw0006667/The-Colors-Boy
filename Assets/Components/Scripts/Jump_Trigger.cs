using UnityEngine;
using System.Collections;

public class Jump_Trigger : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnTriggerEnter(Collider col)
	{
		if (col.tag.Equals(GameDefine.PLAYERNAME))
		{
			col.GetComponent<Robot>().SetCanJump(true);
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		if (col.tag.Equals(GameDefine.PLAYERNAME))
		{
			col.GetComponent<Robot>().SetCanJump(false);	
		}
	}
}
