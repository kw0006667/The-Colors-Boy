using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour
{
    public float Velocity;

    public bool forwardKey;
    public bool backwardKey;
	public bool jumpKey;
    private float axisValue;
    private float axisValueABS;

    protected Animator animator;

    private AnimatorStateInfo baseCurrentStateInfo;


    // Use this for initialization
    void Start()
    {
        this.Velocity = 0.0f;

        this.forwardKey = false;
        this.backwardKey = true;
		this.jumpKey = false;
        this.axisValue = 0.0f;
        this.axisValueABS = 0.0f;

        this.animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.Velocity = this.rigidbody.velocity.magnitude;
        //this.GetInput();
        this.axisValue = Input.GetAxis("Horizontal");
        this.axisValueABS = Mathf.Abs(this.axisValue);

        this.baseCurrentStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);

        this.animator.SetFloat("Speed", this.axisValueABS);

        if (this.axisValue > 0.0f)
        {
            if (this.forwardKey)
            {
                this.rigidbody.transform.rotation *= Quaternion.AngleAxis(-180.0f, Vector3.up);
                this.forwardKey = false;
                this.backwardKey = true;
            }
        }
        if (this.axisValue < 0.0f)
        {
            if (this.backwardKey)
            {
                this.rigidbody.transform.rotation *= Quaternion.AngleAxis(180.0f, Vector3.up);
                this.backwardKey = false;
                this.forwardKey = true;
            }
        }

        //if (Input.GetButtonDown("Jump"))
        //{
        //    this.rigidbody.AddForce(this.transform.TransformDirection(Vector3.up) * 200);
        //}
        //if (this.forwardKey)
        //{
        //    this.animator.SetFloat("Speed", this.axisValue);
        //    this.rigidbody.position += this.animator.deltaPosition * this.axisValue;
        //    //this.rigidbody.position += this.transform.TransformDirection(Vector3.right) * this.axisValue;
        //    //this.rigidbody.AddForce(this.transform.TransformDirection(Vector3.right) * this.axisValue * 1000.0f);
        //}
		
		if (Input.GetButtonDown("Jump"))
		{
			this.jumpKey = true;
		}

        if (Input.GetKey(KeyCode.Space))
        {
            //if (this.baseCurrentStateInfo.Equals("Base.Runs"))
            this.animator.SetBool("Jump", true);
			
			//this.rigidbody.AddForce(this.transform.TransformDirection(Vector3.up) * 100.0f, ForceMode.Force);
        }

        //if (Mathf.Abs(this.rigidbody.velocity.magnitude) > 5)
        //    this.rigidbody.velocity = this.transform.TransformDirection(Vector3.right) * this.axisValue * 100.0f;
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    //this.rigidbody.velocity = this.transform.TransformDirection(Vector3.right) * 10;
        //    this.rigidbody.position += this.transform.TransformDirection(Vector3.right) * 0.01f;
        //}
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    //this.rigidbody.AddForce(this.transform.TransformDirection(Vector3.left) * 100, ForceMode.Force);
        //    //this.rigidbody.velocity = this.transform.TransformDirection(Vector3.left) * 10;
        //    this.rigidbody.position += this.transform.TransformDirection(Vector3.left) * 0.01f;
        //}
    }

    //bool IsFloor()
    //{
    //    CapsuleCollider col = GetComponent<CapsuleCollider>();
    //}

    void GetInput()
    {
        float horizonValue = Input.GetAxis("Horizontal");
        if (horizonValue != 0.0f)
        {
            this.axisValue = horizonValue > 0.0f ? 0.05f : -0.05f;
            this.forwardKey = true;
        }
        else
        {
            this.axisValue = 0.0f;
            this.forwardKey = false;
        }
    }
}
