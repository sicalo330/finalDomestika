using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishGame : MonoBehaviour
{
    public Transform cam;
    public Transform p;
    public AudioSource audioSource;

    void Awake(){
        audioSource = gameObject.AddComponent<AudioSource>(); 
    }

        void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            cam.position = new Vector3(cam.position.x + 28, cam.position.y - 5, cam.position.z);
            p.position = new Vector3(p.position.x + 19, p.position.y - 3, p.position.z);
            audioSource.Stop();
        }
    }
}
