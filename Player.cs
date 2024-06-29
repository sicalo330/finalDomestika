using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Callbacks;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player obj;
    public int lives = 3;
    public bool isGrounded;
    public bool isMoving;
    public float radius = 0.3f;
    public float movHor;
    public float groundRayDist = 0.5f;
    public float speed = 3f;
    public float jumpForce = 3f;
    public float frontCheck = 0.51f;
    public LayerMask groundLayer;
    public Rigidbody2D rb;

    private Animator anim;

    [Header("SaltoPared")]
    [SerializeField] private Transform controller;
    [SerializeField] private Transform wallDimension; 

    [SerializeField] private Vector3 dimensionBox;
    [SerializeField] private bool isWall;
    [SerializeField] private bool slide;
    [SerializeField] private float slideVelocity;
    [SerializeField] private float wallJumpForceX;
    [SerializeField] private float wallJumpForceY;
    [SerializeField] private float wallJumpingTime;
    [SerializeField] public bool canWallJump;
    private bool wallJumping;

    void Awake(){
        obj = this;
    }

    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movHor = Input.GetAxisRaw("Horizontal");
        isMoving = (movHor != 0f);
        isWall = Physics2D.OverlapBox(controller.position, dimensionBox, 0f, groundLayer);
        isGrounded = Physics2D.CircleCast(transform.position, radius, Vector3.down, groundRayDist, groundLayer);

        if(Input.GetKey(KeyCode.Space)){
            jump();
        }

        //Permite saber si el jugador está colisionando con una pared lo que hará que la variable slide sea verdadero
        if(!isGrounded && isWall && movHor != 0f){
            slide = true;
        }else{
            slide = false;
        }

        //Si lo anterior se cumple el jugador se deslizará, la velocidad de deslizamiento dependederá del valor que se tenga
        if(slide){
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -slideVelocity, float.MaxValue));
        }

        //(isWall && slide)
        flip(movHor);

        //Esto permite que el jugador se mueva
        runPlayer();

        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isWall", isWall);
        anim.SetBool("Slide", slide);
    }

    void jump(){
        if (slide)
        {
            if(canWallJump){
                wallJump();
            }else{
                canWallJump = true;
            }
        }
        else if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

    }

    void wallJump(){
        rb.velocity = new Vector2(wallJumpForceX * -movHor, wallJumpForceY);
        slide = false;
        isWall = false;
        StartCoroutine(changeWallJump());
    }

    IEnumerator changeWallJump(){
        wallJumping = true;
        yield return new WaitForSeconds(wallJumpingTime);
        wallJumping = false;
    }
    void runPlayer() {
        if (!wallJumping)
        {
            rb.velocity = new Vector2(movHor * speed, rb.velocity.y);
        }
    }

    //Este es el método que permite mover horizontalmente al personaje
    public void flip(float x){
        Vector3 theScale = transform.localScale;

        if(x < 0){
            theScale.x = Mathf.Abs(theScale.x) * -1;
            transform.localScale = theScale;
        }
        else if(x > 0){
            theScale.x = Mathf.Abs(theScale.x);
            transform.localScale = theScale;
        }
    }

    public void getDamage(){
        lives--;
        if(lives <= 0){
            Game.obj.gameOver();
        }
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controller.position, dimensionBox);    
    }

    void OnDestroy(){
        obj = null;
    }
}
