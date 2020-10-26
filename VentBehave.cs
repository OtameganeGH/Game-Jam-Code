using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentBehave : MonoBehaviour
{
    public float ventTimer;
    public bool ventEnable, ventOn = true;
    public GameObject steam, trigger;
    private AudioSource audio;
    ParticleSystem part;
    // Start is called before the first frame update
    void Start()
    {

        part = steam.GetComponent<ParticleSystem>();
        part.Stop();
        audio = this.GetComponent<AudioSource>();


        if (ventEnable == true)
        {
            StartCoroutine(SteamTiming());
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SteamTiming()
    {

        for (int i = 1; i > 0; i++)
        {
            yield return new WaitForSeconds(ventTimer);
            if (ventOn == false)
            {
                ventOn = true;
                audio.Play();
                part.Play();
                trigger.SetActive(true);
            }
            else if (ventOn == true)
            {
                ventOn = false;
                part.Stop();
                audio.Stop();
                trigger.SetActive(false);
            }
        }

    }
}
