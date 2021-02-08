using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneHelper : MonoBehaviour
{
    public void LoadMainScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
