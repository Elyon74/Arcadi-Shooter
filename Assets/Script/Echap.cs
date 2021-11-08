using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Echap : MonoBehaviour
{

    public void TryAgain()
    {
        Scene Current = SceneManager.GetActiveScene();  // On declare la scene actuelle
        SceneManager.LoadScene(Current.name);   // On relance la scene actuelle
    }

    public void ExitEchapGame()
    {
        Application.Quit();
    }
}
