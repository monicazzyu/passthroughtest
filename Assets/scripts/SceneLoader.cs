using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SceneLoader : MonoBehaviour
{
    public void ChangeScene()
    {
        Debug.Log("123123");
        SceneManager.LoadScene("MusicDemo2", LoadSceneMode.Single);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MusicDemo2"));
    }
}