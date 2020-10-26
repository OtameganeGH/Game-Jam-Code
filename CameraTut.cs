using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTut : MonoBehaviour
{
    bool msgOn = true;
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&msgOn==true)
        {
            cam.SetActive(false);
            msgOn = false;
        }


    }
}
