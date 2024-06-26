using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform bg0;
    public float factor0 = 1f;
    public Transform bg1;
    public float factor1 = 1/2f;
    public Transform bg2;
    public float factor2 = 1/4f;
    private float displacemente;
    private float iniCamposFrame;
    private float nextCamposFrame;
    private float fixedCameraY;

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        fixedCameraY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        iniCamposFrame = transform.position.x;
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }

    void LateUpdate() {
        nextCamposFrame = transform.position.x;

        bg0.position = new Vector3(bg0.position.x + (nextCamposFrame - iniCamposFrame) * factor0, bg0.position.y, bg0.position.z);    
        bg1.position = new Vector3(bg1.position.x + (nextCamposFrame - iniCamposFrame) * factor1, bg1.position.y, bg1.position.z);    
        bg2.position = new Vector3(bg2.position.x + (nextCamposFrame - iniCamposFrame) * factor2, bg2.position.y, bg2.position.z);    
    }
}
