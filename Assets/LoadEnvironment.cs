using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        yield return SceneManager.LoadSceneAsync(envName, UnityEngine.SceneManagement.LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(envName));
        yield break;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
