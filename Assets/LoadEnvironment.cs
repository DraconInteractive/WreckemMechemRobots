using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadEnvironment : MonoBehaviour
{
    public string envName;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Load());
    }

    IEnumerator Load ()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(envName, UnityEngine.SceneManagement.LoadSceneMode.Additive);
        yield break;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
