using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{


   public  bool lightOn, breakReset;
    public GameObject flash;
    public Light lt;
    AudioSource Audio;
    public float lightIntStart, lightIntStartPhase ,lightIntdecrease,  lightDurationTick;
    // Start is called before the first frame update
    void Start()
    {
        Audio = gameObject.GetComponent<AudioSource>();
        lt = flash.GetComponent<Light>();
        lt.intensity.Equals(lightIntStart);
        flash.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (breakReset == true)
        {
            breakReset = false;
            StopCoroutine(FlashTimer());
            lt.intensity = lightIntStart;
            flash.SetActive(false);
            lightOn = false;


        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if(lightOn == false)
            {
               // lt.intensity = lightIntStart;
                flash.SetActive(true);
                StartCoroutine(FlashTimer());
            }
        
            

        }
    }



    IEnumerator FlashTimer()
    {
        lightOn = true;
        Audio.Play();
        yield return new WaitForSeconds(0.1f);

        lt.intensity = lightIntStartPhase;
       
        for (float i = 0.0f; lt.intensity > i;)
         {
             yield return new WaitForSeconds(lightDurationTick/100);
        lt.intensity = lt.intensity - lightIntdecrease;
         }



        lt.intensity = lightIntStart;
        flash.SetActive(false);
        lightOn = false;

    }
}
