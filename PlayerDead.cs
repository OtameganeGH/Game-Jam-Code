using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    AudioSource audio;
    public AudioClip ACDeath;
    public GameObject UIDeath, camera;
    public Vector3 currCheckPoint;
    public bool playerDead = false;
    // Start is called before the first frame update
    void Start()
    {
        audio = camera.GetComponent<AudioSource>();
        currCheckPoint = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)&& playerDead == true)
        {
            this.transform.position = currCheckPoint;
            UIDeath.SetActive(false);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Death")
        {
            audio.PlayOneShot(ACDeath, 1);
            UIDeath.SetActive(true);
            playerDead = true;
            this.gameObject.SetActive(false);

        }

        if (other.gameObject.tag == "Checkpoint")
        {
            currCheckPoint = other.transform.position;
        }
    }



}
