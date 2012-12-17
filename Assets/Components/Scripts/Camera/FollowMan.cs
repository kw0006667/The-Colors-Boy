using UnityEngine;
using System.Collections;

public class FollowMan : MonoBehaviour {
	
	public GameObject Target;
    public float Height = 0.0f;
    public float RefreshTime = 1.0f;
	
	private Vector3 currentCameraPosition;
	private float mathClamp;

    private float totalTime;
    private float prevPositionY;
    private float currentPositionY;
	
	// Use this for initialization
	void Start () 
	{
		this.currentCameraPosition = new Vector3(this.transform.position.x, this.Target.transform.position.y, this.Target.transform.position.z);
		this.transform.position = this.currentCameraPosition;

        this.prevPositionY = this.Target.transform.position.y;
        this.currentPositionY = this.Target.transform.position.y;
        this.totalTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
        this.totalTime += Time.deltaTime;
        if (this.totalTime >= this.RefreshTime)
        {
            this.currentPositionY = this.Target.transform.position.y;
            this.totalTime = 0.0f;
        }
        if ( Mathf.Abs(this.currentPositionY - this.prevPositionY) >= 0.6f)
            this.currentCameraPosition = new Vector3(this.transform.position.x, this.Target.transform.position.y, this.Target.transform.position.z);
        else
		    this.currentCameraPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.Target.transform.position.z);
		this.transform.position = this.currentCameraPosition;
        this.prevPositionY = this.Target.transform.position.y;
	}
}
