using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public void NewGame()
    {
        SceneManager.LoadScene(0);  // On charge la scene avec l' index 1 dans le buildsettings du projet
    }
    public void ExitDeadGame()
    {
        Application.Quit();
    }
}
