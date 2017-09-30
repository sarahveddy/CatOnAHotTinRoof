using UnityEngine;
using System.Collections;

public class PlatformerMovement : MonoBehaviour
{

    Rigidbody2D r_body;
    Animator anim;

    public float jump_force;
    public float move_force;

	protected bool facingRight = true;
	protected bool jump = true;
	protected bool isGrounded = false;

	public float maxSpeed = 2000000f;


	void Start()
    {

        r_body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {

        // get spacebar input and jump
		if (Input.GetButtonDown("Jump") && isGrounded /*&& IsGrounded()*/)
        {
			anim.SetBool("Jump", true);
			isGrounded = false;
			// jump - add force up
            r_body.AddForce(new Vector2(0, jump_force));
			// play jump animation

        }
    }

    void FixedUpdate()
    {
        // get left/right , a/d 
        float h = Input.GetAxis("Horizontal");
        // add forces for movement

        r_body.AddForce(new Vector2(h * move_force, 0));

        anim.SetFloat("Speed", Mathf.Abs(h));

//		if (r_body.velocity.magnitude > maxSpeed){
//			r_body.velocity = r_body.velocity.normalized * maxSpeed;
//		}
    }

//	void OnCollisionStay2D(Collision2D collision){
//		isGrounded = true;
//	}
	void OnCollisionEnter2D(Collision2D collision){
		isGrounded = true;
		anim.SetBool ("Jump", false);
	}
}