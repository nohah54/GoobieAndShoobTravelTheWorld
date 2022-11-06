using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string next_scene;

    public void SwitchScene()
    {
        SceneManager.LoadScene(next_scene);
    }
}
