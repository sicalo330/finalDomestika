using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isMoving = false;
    public float speed = 3f;
    public float movHor = 1f;
    public float frontCheck = 0.51f;
    public float radius = 0.3f;
    public float groundRayDist = 0.5f;
    public bool isGroundFloor = false;
    public bool isGroundFront = false;

    private Animator anim;

    public LayerMask groundLayer;

    [Header("Evitar caer en precipicio")]
    [SerializeField] private Transform controller;
    [SerializeField] private Vector3 dimensionBox;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        //En este caso usaré un controlador que funciona como auxiliar, este será el encargado de detectar si hay o no hay un precipicio
        //Esto detecta si el enemigo está en el suelo lo que será útil a la hora de hacer su animación de correr y para que pueda correr
        isGroundFloor = Physics2D.OverlapBox(controller.position, dimensionBox, 0f, groundLayer);
        //Evita caer en precipicio
        //Raycast detecta colisiones y lo toma como true o false
        if(!isGroundFloor){
            movHor = movHor * -1;
        }

        if(movHor != 0){
            isMoving = true;
        }

        flip(movHor);
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGroundedFloor", isGroundFloor);
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(movHor * speed, rb.velocity.y);    
    }

    void flip(float x){
        Vector3 theScale = transform.localScale;
        if(x < 0){
            theScale.x = Mathf.Abs(theScale.x);
            transform.localScale = theScale;
        }else if(x > 0){
            theScale.x = Mathf.Abs(theScale.x) * -1;
            transform.localScale = theScale;
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controller.position, dimensionBox);
    }
}
