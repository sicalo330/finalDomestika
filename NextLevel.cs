using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public int next = 19;
    public Transform cam;
    public Transform p;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            cam.position = new Vector3(cam.position.x + next, cam.position.y, cam.position.z);
            p.position = new Vector3(p.position.x + next + 1, p.position.y - 3, p.position.z);
        }       
    }
}
