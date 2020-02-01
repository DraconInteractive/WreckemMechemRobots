using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class EntryWarning : MonoBehaviour
{
    public bool botIncoming;
    public Light pulsingLight, spiningLight;
    public AudioClip warningDialouge;
    AudioSource audioplayer;

    float fadeCounter, lightAngle;
    bool countUp = true;
    
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
            pulsingLight.enabled = true;
            spiningLight.enabled = true;

            lightAngle += Time.deltaTime;
            lightAngle = Mathf.Clamp(lightAngle, 0, 5);
            spiningLight.transform.Rotate(Vector3.up, lightAngle);

            if (countUp)
            {
                fadeCounter += Time.deltaTime;
                if(fadeCounter > 2)
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

            pulsingLight.intensity = fadeCounter;

        }
        else
        {
            pulsingLight.enabled = false;
            spiningLight.enabled = false;
            lightAngle = 0;
        }
    }
}
