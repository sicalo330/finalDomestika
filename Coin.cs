using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreGive = 100;
    public Rigidbody2D rb;

    public float fallDellay = 2f;
    public float fallSpeed = 2f;
    public bool fall;

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player")){
            Game.obj.addScore(scoreGive);
            //StartCoroutine(StartFalling());
            gameObject.SetActive(false);
        }
    }

    IEnumerator StartFalling(){
        yield return new WaitForSeconds(fallDellay);
        fall = true;
    }

    void Update(){
        if(fall){
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        }
    }
}
