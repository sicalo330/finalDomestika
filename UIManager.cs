using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager obj;
    public Text livesLbl;
    public Text scoreLbl;
    public Transform UIPanel;
    private AudioSource audioBackGround;

    void Awake(){
        obj = this;
    }

    public void UpdateLives(){
        livesLbl.text    = "" + Player.obj.lives;
    }

    public void updateScore(){
        scoreLbl.text = "" + Game.obj.score;
    }

    public void StartGame(){

        Game.obj.gamePaused = true;
        UIPanel.gameObject.SetActive(true);    
    }

    public void hideInitPanel(){
        Game.obj.gamePaused = false;
        UIPanel.gameObject.SetActive(false);    
    }

    public void finishGame(){
        //Este es el metodo que debería reproducir el sonido de victoria, aun etoy pendiente de cual resproducir
        Game.obj.gamePaused = true;
        audioBackGround = AudioManager.obj.gameObject.AddComponent<AudioSource>();
        audioBackGround.Stop();
    }

    void OnDestroy(){
        obj = null;
    }
}
