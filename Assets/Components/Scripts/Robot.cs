using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour
{
    public float Velocity;

    public bool ForwardKey;
    public bool BackwardKey;
	public bool JumpKey;

    // if the Man can jump(climb)
    public bool canJump;

    private float axisValue;
    private float axisValueABS;

    protected Animator animator;

    private AnimatorStateInfo baseCurrentStateInfo;

    private CapsuleCollider col;


    // Use this for initialization
    void Start()
    {
        this.Velocity = 0.0f;

        this.ForwardKey = false;
        this.BackwardKey = true;
		this.JumpKey = false;
        this.canJump = false;
        this.axisValue = 0.0f;
        this.axisValueABS = 0.0f;

        this.animator = this.GetComponent<Animator>();
        this.col = this.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //this.Velocity = this.rigidbody.velocity.magnitude;
        ////this.GetInput();
        //this.axisValue = Input.GetAxis("Horizontal");
        //this.axisValueABS = Mathf.Abs(this.axisValue);

        //this.baseCurrentStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);

        //this.animator.SetFloat("Speed", this.axisValueABS);

        //if (this.axisValue > 0.0f)
        //{
        //    if (this.ForwardKey)
        //    {
        //        this.rigidbody.transform.rotation *= Quaternion.AngleAxis(-180.0f, Vector3.up);
        //        this.ForwardKey = false;
        //        this.BackwardKey = true;
        //    }
        //}
        //if (this.axisValue < 0.0f)
        //{
        //    if (this.BackwardKey)
        //    {
        //        this.rigidbody.transform.rotation *= Quaternion.AngleAxis(180.0f, Vector3.up);
        //        this.BackwardKey = false;
        //        this.ForwardKey = true;
        //    }
        //}
		
        //if (Input.GetButtonDown("Jump"))
        //{
        //    this.JumpKey = true;
        //}

        //if (Input.GetKey(KeyCode.Space))
        //{
        //    //if (this.baseCurrentStateInfo.Equals("Base.Runs"))
        //    this.animator.SetBool("Jump", true);
			
        //    //this.rigidbody.AddForce(this.transform.TransformDirection(Vector3.up) * 100.0f, ForceMode.Force);
        //}

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

    void FixedUpdate()
    {
        this.axisValue = Input.GetAxis("Horizontal");
        this.axisValueABS = Mathf.Abs(this.axisValue);

        if (this.animator)
        {
            this.animator.SetFloat("Speed", this.axisValueABS);

            this.baseCurrentStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);

            // Check the animator is forward or backward
            if (this.axisValue > 0.0f)
            {
                if (this.ForwardKey)
                {
                    this.rigidbody.transform.rotation *= Quaternion.AngleAxis(-180.0f, Vector3.up);
                    this.ForwardKey = false;
                    this.BackwardKey = true;
                }
            }
            if (this.axisValue < 0.0f)
            {
                if (this.BackwardKey)
                {
                    this.rigidbody.transform.rotation *= Quaternion.AngleAxis(180.0f, Vector3.up);
                    this.BackwardKey = false;
                    this.ForwardKey = true;
                }
            }

            if ( (!this.baseCurrentStateInfo.IsName("Base.Jump") 
				|| this.baseCurrentStateInfo.IsName("Base.Idle") 
				|| this.baseCurrentStateInfo.IsName("Base.Walk") 
				|| this.baseCurrentStateInfo.IsName("Base.Run")) && this.canJump)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    this.animator.SetBool("Jump", true);
                }
            }
            else if (this.baseCurrentStateInfo.IsName("Base.Jump") && !this.animator.IsInTransition(0))
            {
                this.animator.SetBool("Jump", false);


                this.col.center = new Vector3(0, this.animator.GetFloat("ColliderY"), 0);
                this.col.height = this.animator.GetFloat("ColliderHeight");
            }
        }
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
            this.ForwardKey = true;
        }
        else
        {
            this.axisValue = 0.0f;
            this.ForwardKey = false;
        }
    }
	
	public void SetCanJump(bool isCanJump)
	{
		this.canJump = isCanJump;
	}
}
