using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonToSaveMovement : MonoBehaviour {

    public CharacterController2D controller;
    GameObject Player;
    private float horizontalMove;
    private bool jump;
    private bool crouch;
    private bool attack;
    public float runSpeed = 35f;
    public int jumpChance = 2; //out of 1000
    public int attackChance = 50;
    public float runAwayDistance;


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
    void Update()
    {
        if (anime != null)
            anime.SetFloat("Speed", Mathf.Abs(horizontalMove));
        horizontalMove = 0;
        float distanceFromPlayer = Mathf.Abs(Player.transform.position.x - this.transform.position.x);
        if (distanceFromPlayer < runAwayDistance )
        {
            if (this.transform.position.x < Player.transform.position.x)
            {
                horizontalMove = -runSpeed;
            }
            else
                horizontalMove = runSpeed;
        }
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, attack);
        jump = false;
    }
}