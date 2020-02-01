using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbeinceController : MonoBehaviour
{
    public bool doorOpen;
    AudioSource audioplayer;
    // Start is called before the first frame update
    void Start()
    {
        audioplayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (doorOpen)
        {
            audioplayer.volume = 1f;
        }
        else
        {
            audioplayer.volume = 0.1f;
        }
    }
}
