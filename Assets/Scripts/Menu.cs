using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("Level");
    }

    public void ToInfo()
    {
        SceneManager.LoadScene("Info");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
