using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(AudioSource))]

public class WeldableHole : MonoBehaviour
{
    [Header("Joint Settings")]
    public float triggerSize;
    public AudioClip weldClips;
    public bool isLeft;
    public float weldingLength;

    bool tipInside;
    float greasedTimer;
    AudioSource audioPlayer;

    // Update is called once per frame
    void Update()
    {
        if (tipInside && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, isLeft ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch))
        {
            greasedTimer += Time.deltaTime;
            PlaySqueak();

            if (greasedTimer >= weldingLength)
            {
                this.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Greaser"))
        {
            tipInside = true;
            audioPlayer.loop = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Greaser"))
        {
            tipInside = false;
            audioPlayer.loop = false;
        }
    }

    private void PlaySqueak()
    {
        audioPlayer.clip = weldClips;
        if (!audioPlayer.isPlaying)
        {
            audioPlayer.Play();
        }
    }
}
