using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlink : MonoBehaviour
{
    AudioSource audioplayer;
    public AudioClip bulletNoise;

    // Start is called before the first frame update
    void Start()
    {
       audioplayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float diceRoll = Random.Range(0f, 1f);
        print(diceRoll);
        if (diceRoll < 0.0001)
        {

            this.gameObject.transform.position = new Vector3(15, Random.Range(-5, 5.0f), Random.Range(-15.0f, 15));
            audioplayer.PlayOneShot(bulletNoise);
        }
    }
}
