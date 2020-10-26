using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatRespawn : MonoBehaviour
{
    public GameObject platform;
    Vector3 PlatStartPos;
    Quaternion PlatStartRot;
    public float respawnTime;
    // Start is called before the first frame update
    void Start()
    {
        PlatStartPos = platform.transform.position;
        PlatStartRot = platform.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (platform.activeSelf == false)
        {
            StartCoroutine(ResetTimer());
        }
    }



    IEnumerator ResetTimer()
    {
        yield return new WaitForSeconds(respawnTime);
        platform.transform.position = PlatStartPos;
        platform.transform.rotation = PlatStartRot;
        platform.SetActive(true);


    }
}
