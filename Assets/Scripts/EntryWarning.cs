using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class EntryWarning : MonoBehaviour
{
    public bool botIncoming;
    public Light pulsingLight, spiningLight;
    public AudioClip alarm;
    public AudioClip warningDialouge;
    AudioSource audioplayer;

    float fadeCounter, lightAngle, alarmCounter, alarmTriggers;
    bool countUp = true, alarmDoOnce = true;
    
    // Start is called before the first frame update
    void Start()
    {
        audioplayer = GetComponent<AudioSource>();
        pulsingLight.enabled = false;
        spiningLight.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (botIncoming)
        {
            if (alarmDoOnce)
            {
                audioplayer.PlayOneShot(alarm);
                alarmDoOnce = false;
            }

            pulsingLight.enabled = true;
            spiningLight.enabled = true;

            lightAngle += Time.deltaTime;
            lightAngle = Mathf.Clamp(lightAngle, 0, 3);
            spiningLight.transform.Rotate(Vector3.up, lightAngle);

            if (countUp)
            {
                fadeCounter += Time.deltaTime;
                if(fadeCounter > 0.5)
                {
                    countUp = false;
                }
            }
            else
            {
                fadeCounter -= Time.deltaTime;
                if (fadeCounter < 0)
                {
                    countUp = true;
                }
            }
 
            pulsingLight.intensity = fadeCounter*200;

            alarmCounter += Time.deltaTime;
            if(alarmCounter >  1.5)
            {
                alarmCounter = 0;
                audioplayer.PlayOneShot(alarm);
            }

        }
        else
        {
            pulsingLight.enabled = false;
            spiningLight.enabled = false;
            lightAngle = 0;
            alarmCounter = 0;
            alarmDoOnce = true;
        }
    }
}
