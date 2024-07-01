using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public static NextLevel obj;
    public int next;
    public int yDiference;
    public int levels = 1;
    public bool finish = false;
    public Transform cam;
    public Transform p;

    void OnTriggerEnter2D(Collider2D other) {
        if(levels >= 2){
            yDiference = 10;
            next = 25;
        }

        if(other.gameObject.CompareTag("Player") && levels < 2){
            cam.position = new Vector3(cam.position.x + 19, cam.position.y, cam.position.z);
            p.position = new Vector3(p.position.x + 19, p.position.y - 3, p.position.z);
            AudioManager.obj.playWin();
            levels += 1;
        }
    }
}
