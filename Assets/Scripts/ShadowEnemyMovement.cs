using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowEnemyMovement : MonoBehaviour {

    public CharacterController2D controller;
    GameObject Player;
    private float horizontalMove;
    private bool jump;
    private bool crouch;
    private bool attack;
    public float runSpeed = 35f;
    public float attackModeRange = 25f;
    public int jumpChance = 2; //out of 1000

    enum enemystate { searching, attacking };
    [SerializeField]
    enemystate enemyState = enemystate.searching;

    void Awake()
    {
        Player = FindObjectOfType<PlayerMovement2D>().gameObject;
    }
	void Update ()
    {
        switch (enemyState)
        {
            case enemystate.searching:
                Seek();
                break;
            case enemystate.attacking:
                AttackMode();
                break;
            default:
                break;
        }
    }


    private void AttackMode()
    {
       
    }

    private void Seek()
    {
        Debug.Log("seeking");
        if (Player.transform.position.x > transform.position.x) //Player is to the right of this enemy
        {
            horizontalMove = runSpeed;
        }
        else
        {
            horizontalMove = -runSpeed;
        }
        System.Random rand = new System.Random();
        if(rand.Next(0,1000) <= jumpChance)
        {
            jump = true;
        }

        //if player is within range switch to attacking
        /*
        if(Mathf.Abs(Player.transform.position.x - transform.position.x) >= attackModeRange)
        {
            enemyState = enemystate.attacking;
        }
        */
    }


    
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, attack);
        jump = false;
    }
}
