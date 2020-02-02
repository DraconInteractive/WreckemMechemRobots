using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starer : MonoBehaviour
{
    public void Grab ()
    {
        HeadController.Instance.starers++;
    }

    public void Release ()
    {
        HeadController.Instance.starers--;
    }
}
