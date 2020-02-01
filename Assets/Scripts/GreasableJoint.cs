using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(AudioSource))]

public class GreasableJoint : MonoBehaviour
{
    public SphereCollider jointTrigger;
    AudioSource audioPlayer;

    bool tipInside;
    public UnityEvent onGreased;
    float greasedTimer;

    [Header("Joint Settings")]
    public float triggerSize;
    public AudioClip[] squeakClips;
    public AudioClip weldClip;
    public bool isLeft;
    public float greasingLength;

    void Awake()
    {
        jointTrigger.radius = triggerSize;
    }

    void Update()
    {
        if (tipInside && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, isLeft ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch))
        {
            greasedTimer += Time.deltaTime;
            PlayGreaser();

            if (greasedTimer >= greasingLength) {
                onGreased?.Invoke();
                this.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Welder"))
        {
            tipInside = true;
        }  
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Welder"))
        {
            tipInside = false;
        }
    }

    private void PlaySqueak()
    {
        int soundNumToPlay = Random.Range(0, squeakClips.Length - 1);
        audioPlayer.PlayOneShot(squeakClips[soundNumToPlay]);
    }

    private void PlayGreaser()
    {
        audioPlayer.clip = weldClip;
        if (!audioPlayer.isPlaying)
        {
            audioPlayer.Play();
        }
    }

}
