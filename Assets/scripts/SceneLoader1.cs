using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SceneLoader1 : MonoBehaviour
{
    public void ChangeSceneBack()
    {
        Debug.Log("123123");
        SceneManager.LoadScene("MusicDemo1", LoadSceneMode.Single);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MusicDemo1"));
    }
}