using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    
    public CharacterController2D controller;
    public Animator anime;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    bool attack = false;
    public UnityEngine.UI.Text healthText;

    void Awake()
    {
        controller.OnLandEvent.AddListener(OnLanding);
    }
    // Update is called once per frame
    void Update()
    {
        healthText.text = "Player Health: " + controller.characterHealth;
        if (anime != null)
            anime.SetFloat("Speed", Mathf.Abs(horizontalMove));

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("attack"))
        {
            Debug.Log("attack");
            attack = true;
        }
        else
            attack = false;
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jumping");
            jump = true;
            if(anime != null)
                anime.SetBool("Jumping", true);
            //controller.timeOfJump = Time.time;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
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
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump,attack);
        jump = false;
    }
}
