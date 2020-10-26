 using System.Collections;
 using UnityEngine;
 
 public class FallingPlatform : MonoBehaviour
 {
    public float fallDelay;
    public AudioClip creak, snap;
    public AudioSource audio;
    bool breaking;
     
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }


     void OnCollisionEnter(Collision collidedWithThis)
     {
         if (collidedWithThis.gameObject.name == "Player" && breaking == false)
         {
            breaking = true;
             StartCoroutine(FallAfterDelay());
         }
     }
 
     IEnumerator FallAfterDelay()
     {
        audio.PlayOneShot(creak, 1);
         yield return new WaitForSeconds(fallDelay);
         GetComponent<Rigidbody>().isKinematic = false;
        audio.PlayOneShot(snap, 1);
        yield return new WaitForSeconds(1.0f);
        breaking = false;
        GetComponent<Rigidbody>().isKinematic = true;
        gameObject.SetActive(false);

    }
 }