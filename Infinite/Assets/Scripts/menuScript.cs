using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {

    public void quitGame()
    {
        Application.Quit();
    }

    public void playGame()
    {
        SceneManager.LoadScene("gameScene", LoadSceneMode.Single);
    }
}