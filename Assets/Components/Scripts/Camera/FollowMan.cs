using UnityEngine;
using System.Collections;

public class FollowMan : MonoBehaviour {
	
	public GameObject Target;
	
	private Vector3 currentCameraPosition;
	private float mathClamp;
	
	// Use this for initialization
	void Start () 
	{
		this.currentCameraPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.Target.transform.position.z);
		this.transform.position = this.currentCameraPosition;
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.currentCameraPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.Target.transform.position.z);
		this.transform.position = this.currentCameraPosition;
	}
}
