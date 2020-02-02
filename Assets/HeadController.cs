using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{
    public static HeadController Instance;
    public int starers;
    Transform mainCam;
    Quaternion init;
    public float lerpSpeed;
    public Transform[] eyes;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main.transform;
        init = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (starers > 0)
        {
            //transform.LookAt(mainCam);
            Vector3 dir = (mainCam.position - transform.position).normalized;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir, Vector3.up)* Quaternion.Euler(new Vector3(-90, 0,0)), lerpSpeed * Time.deltaTime);

            foreach(Transform t in eyes)
            {
                t.rotation = Quaternion.LookRotation(dir, Vector3.up) * Quaternion.Euler(new Vector3(-90, 0, 0));
            }
        } else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, init, lerpSpeed * Time.deltaTime);

            foreach (Transform t in eyes)
            {
                t.rotation = init;
            }
        }
    }
}
