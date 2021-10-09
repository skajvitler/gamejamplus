using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public CharacterController2D controller;
	private Rigidbody2D rb;
	private Animator anim;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	float value = 0f;

	private void Start ()
    {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update()
	{

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		value = Input.GetAxis("Horizontal");

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

		if (value < 0 || value > 0)
		{
			anim.SetBool("isRunning", true);
		}
		else 
		{
			anim.SetBool("isRunning", false);
		}

		if (Input.GetKeyDown(KeyCode.Space))
        {
			anim.SetTrigger("isJumping");
        } 
		else
        {
			anim.ResetTrigger("isJumping");
        }

	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}