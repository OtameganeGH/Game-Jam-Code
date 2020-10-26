using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    CapsuleCollider characterCollider;
    private bool onGround = true, lookingLeft = false;
    private float scaleY;
    public GameObject body;
    
    // Start is called before the first frame update
    void Start()
    {
        characterCollider = gameObject.GetComponent<CapsuleCollider>();
        scaleY = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float strafe = Input.GetAxis("Horizontal") * speed;
        float surge = Input.GetAxis("Vertical") * speed;
        strafe *= Time.deltaTime;

        transform.Translate(strafe, 0, 0);

        //Sprint
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 9.0f;
        }
        else
        {
            speed = 6.0f;
        }
        //Jumping
        RaycastHit hit;
        Vector3 physicsCentre = this.transform.position + this.GetComponent<CapsuleCollider>().center;

        if(Physics.Raycast(physicsCentre, Vector3.down, out hit, 2.0f))
        {
            if (hit.transform.gameObject.name != "Player")
            {
                onGround = true;
            }
        }
        else
        {
            onGround = false;
        }
        //Debug.Log(onGround);

        if(Input.GetKeyDown(KeyCode.W) && onGround)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
        }

      

        if (Input.GetKeyDown(KeyCode.A)&& lookingLeft == false)
        {
            lookingLeft = true;
            //gameObject.transform.rotation = new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y + 180, gameObject.transform.rotation.z);
            Vector3 rot = body.transform.rotation.eulerAngles;
            rot = new Vector3(rot.x, rot.y + 180, rot.z);
            body.transform.rotation = Quaternion.Euler(rot);
        }
        if (Input.GetKeyDown(KeyCode.D) && lookingLeft == true)
        {
            lookingLeft = false;
            Vector3 rot = body.transform.rotation.eulerAngles;
            rot = new Vector3(rot.x, rot.y - 180, rot.z);
            body.transform.rotation = Quaternion.Euler(rot);
        }
        // gameObject.transform.rotation = new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y - 180, gameObject.transform.rotation.z);

    }
    
}

