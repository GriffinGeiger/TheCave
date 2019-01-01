using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController controller;
    public Animator anime;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
	
    void Awake ()
    {
        controller.OnLandEvent.AddListener(OnLanding);
    }
	// Update is called once per frame
	void Update ()
    {
        
        anime.SetFloat("Speed", Mathf.Abs(horizontalMove));
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if(Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jumping");
            jump = true;
            anime.SetBool("Jumping", true);
            controller.timeOfJump = Time.time;
        }
        
        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
	}
    public void OnLanding()
    {
        anime.SetBool("Jumping", false);
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
