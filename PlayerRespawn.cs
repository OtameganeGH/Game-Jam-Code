using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject Player, UIDeathcam, flashHold;


    bool PlayerDead;
    Vector3 checkPoint;
    float lightInt;
 
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        flashHold = GameObject.Find("LightHolder");
        UIDeathcam = Player.GetComponent<PlayerDead>().UIDeath;
     
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDead = Player.GetComponent<PlayerDead>().playerDead;
        checkPoint = Player.GetComponent<PlayerDead>().currCheckPoint;
      
        if (Input.GetKeyDown(KeyCode.R) && PlayerDead == true)
        {
            Player.transform.position = checkPoint;
            UIDeathcam.SetActive(false);
            Player.SetActive(true);
            Player.GetComponent<PlayerDead>().playerDead = false;
            flashHold.GetComponent<LightSwitch>().breakReset = true;



        }
    }
}
