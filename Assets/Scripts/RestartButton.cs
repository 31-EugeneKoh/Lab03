using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void Level2()
    {
        SceneManager.LoadScene("GamePlay_Level2");
    }
    public void OnRestart()
    {
        SceneManager.LoadScene("GamePlay_Level 1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
