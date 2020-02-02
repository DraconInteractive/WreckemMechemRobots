using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqueakyBoi : MonoBehaviour
{
    public AudioSource source;
    bool grabbed = false;

    public void Grab ()
    {
        grabbed = true;
        source.Play();
        Debug.LogWarning("Squeaky Grab");
    }

    public void Release ()
    {
        grabbed = false;
        source.Stop();
    }

}
