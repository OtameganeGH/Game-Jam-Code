using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnviroMovement : MonoBehaviour
{
    CapsuleCollider characterCollider;
    public GameObject end;

    // Start is called before the first frame update
    void Start()
    {
        characterCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    void OnTriggerStay(Collider other)
    {
        //Debug.Log("Collided with" + other.gameObject.name);
        if (other.gameObject.tag == "Up")
        {
            Debug.Log("Triggered");
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 10.0f, 0), ForceMode.Acceleration);
            Debug.Log("up");
        }
        else if (other.gameObject.tag == "Down")
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, -20.0f, 0), ForceMode.Acceleration);
        }
        else if (other.gameObject.tag == "finish")
        {
            end.SetActive(true);
        }
    }
}
