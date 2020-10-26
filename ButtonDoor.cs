using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonDoor : MonoBehaviour
{
    public GameObject text;
    public GameObject door;
    bool isOpened = false;
    Animator doorAnim;

    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        doorAnim = door.GetComponent<Animator>();
        doorAnim.enabled = false;

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Button")
        {
           
            text.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E) && isOpened == false)
            {
                text.SetActive(false);
                isOpened = true;
                StartCoroutine(Reset());
                doorAnim.enabled = true;
                if (doorAnim.enabled == true)
                
                    {
                    
                        //doorAnim.Play();
                        door.GetComponent<Animator>().Play("DoorAnimation",0,0);
                        
                    }
                
            }
        }
    }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Button")
            {
           
                text.SetActive(false);
            }
        }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(24.0f);
           isOpened = false; 

    }

    }