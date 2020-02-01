using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadEnvironment : MonoBehaviour
{
    public string envName;
    public Transform playerStart, player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Load());
    }

    IEnumerator Load ()
    {
        player.position = playerStart.position;
        player.rotation = playerStart.rotation;
        yield return SceneManager.LoadSceneAsync(envName, UnityEngine.SceneManagement.LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(envName));
        yield break;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
