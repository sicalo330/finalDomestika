using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public static Cam obj;
    public Transform bg;
    void OnTriggerEnter2D(Collider2D other){
            int movCamX = 19;
            int movCamY = 13;
            // Obten la posición del objeto con el que colisionó
            Vector3 otherPosition = other.transform.position;

            // Obten la posición del objeto actual
            Vector3 thisPosition = transform.position;

            // Calcula la diferencia en las posiciones
            Vector3 triggerDirection = otherPosition - thisPosition;

            // Verifica en qué eje fue más grande la diferencia para determinar el eje de colisión
            if (Mathf.Abs(triggerDirection.x) > Mathf.Abs(triggerDirection.y))
            {
                movCamY = 0;
                //El jugador viene desde la izquierda por lo tanto movCamX debe ser negativo
                if(other.gameObject.CompareTag("Player") && (Player.obj.transform.position.x >= transform.position.x)){
                    movCamX = movCamX * -1;
                }
                changeCamPosition(movCamX, movCamY);
            }
            else{
                movCamX = 0;
                if(other.gameObject.CompareTag("Player") && (Player.obj.transform.position.y >= transform.position.y)){
                    movCamY = movCamY * -1;
                }
                changeCamPosition(movCamX, movCamY);
            }
    }

    void changeCamPosition(int movCamX, int movCamY){
        bg.position = new Vector3(bg.position.x + movCamX, bg.position.y + movCamY, bg.position.z);
    }
}