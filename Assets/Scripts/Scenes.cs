using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
     public void NextLevel(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }
}
