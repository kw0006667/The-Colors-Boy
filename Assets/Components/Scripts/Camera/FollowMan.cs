using UnityEngine;
using System.Collections;

public class FollowMan : MonoBehaviour {
	
	public GameObject Target;
    public float Height = 0.0f;
	
	private Vector3 currentCameraPosition;
	private float mathClamp;
	
	// Use this for initialization
	void Start () 
	{
		this.currentCameraPosition = new Vector3(this.transform.position.x, this.Target.transform.position.y, this.Target.transform.position.z);
		this.transform.position = this.currentCameraPosition;
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.currentCameraPosition = new Vector3(this.transform.position.x, this.Target.transform.position.y, this.Target.transform.position.z);
		this.transform.position = this.currentCameraPosition;
	}
}
