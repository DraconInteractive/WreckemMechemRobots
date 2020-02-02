using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilCan : MonoBehaviour
{
    public Transform oilPoint;
    public float oilDist;
    public AudioSource source;
    public void Oil ()
    {
        SqueakyBoi[] bois = GameObject.FindObjectsOfType<SqueakyBoi>();
        List<Transform> toDestroy = new List<Transform>();
        foreach (SqueakyBoi boi in bois)
        {
            if (Vector3.Distance(boi.transform.position, oilPoint.position) < oilDist)
            {
                AudioSource source = boi.GetComponent<AudioSource>();
                if (source != null)
                {
                    Destroy(source);
                }
                toDestroy.Add(boi.transform);
            }
        }

        foreach (Transform t in toDestroy)
        {
            Destroy(t.GetComponent<SqueakyBoi>());
        }

        source.Play();
    }

}
