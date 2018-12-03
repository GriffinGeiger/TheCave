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
    public int attackChance = 50;
    public int soundChance = 1;
    public float attackSpeedup = 1.25f;
    public float attackDistance;
    public float tooCloseDistance;



    System.Random rand = new System.Random();
    AudioManager audioManager;
    public Animator anime;

    enum enemystate { searching, attacking };
    [SerializeField]
    enemystate enemyState = enemystate.searching;

    void Awake()
    {
        Player = FindObjectOfType<PlayerMovement2D>().gameObject;
        audioManager = FindObjectOfType<AudioManager>();
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
        if(rand.Next(0,1000)<=soundChance)
        {
            audioManager.Play("ShadowIdle");
        }
        if (Player.transform.position.x > transform.position.x) //Player is to the right of this enemy
        {
            horizontalMove = attackSpeedup * runSpeed;
        }
        else
        {
            horizontalMove = attackSpeedup* (-runSpeed);
        }
        if (Mathf.Abs(Player.transform.position.x - transform.position.x) < attackDistance)
        {
            if (rand.Next(0, 1000) <= 2*jumpChance)
            {
                jump = true;
            }
            if (rand.Next(0, 1000) <= attackChance)
            {
                anime.SetBool("Attacking", true);

                //attack = true;
            }
        }

        if(Mathf.Abs(Player.transform.position.x - transform.position.x) < tooCloseDistance)
        {
            if (Player.transform.position.x > transform.position.x) //Player is to the right of this enemy
            {
                horizontalMove = -runSpeed;
            }
            else
            {
                horizontalMove = runSpeed;
            }
        }
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
        if(rand.Next(0,1000) <= jumpChance)
        {
            jump = true;
        }

        //if player is within range switch to attacking
        if(Mathf.Abs(Player.transform.position.x - transform.position.x) <= attackModeRange)
        {
            enemyState = enemystate.attacking;
        }
    }


    
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, attack);
        jump = false;
        attack = false;
    }

    void Attack()
    {
        controller.Attack();
    }

    void AttackEnded()
    {
        anime.SetBool("Attacking", false);
    }
}
