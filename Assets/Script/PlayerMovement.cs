using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	// Update is called once per frame
	void Update () {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;//mueve al personaje

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));//si el personaje se mueve activa la animacion

		if (Input.GetButtonDown("Jump")&&!jump)//si oprime el boton para saltar se activa la animacion para saltar
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}

		if (Input.GetButton("Crouch"))//si oprime el boton para agachar se activa la animacion para agachar
		{
			crouch = true;
			animator.SetBool("IsCrouching", true);
			
		}else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
			animator.SetBool("IsCrouching", false);
		}

        if (Input.GetButtonDown("Fire")&&(horizontalMove==0||crouch))//si se presiona z y (el personaje no se mueve o esta agachado)
        {
            this.transform.position=new Vector3(this.transform.position.x,this.transform.position.y+0.02f,transform.position.z);
        }

        if(Input.GetButtonDown("Fire")&&(horizontalMove>=0.1f||horizontalMove<=0.1f))
        {
            animator.SetBool("Fire", true);
        }

        else if(Input.GetButton("Fire"))
        {
            animator.SetBool("Fire", false); 
        }
		
	}

	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
	}

	/*public void OnCrouching (bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}*/

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}