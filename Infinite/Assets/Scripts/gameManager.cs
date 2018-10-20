using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {

    public static gameManager instance; 

    public float score;
    float highScore;
    public float pointsPerSec;
    public Text PlayerName;

    UIManager um;

    //Attempt to make instance on awake
    private void Awake()
    {
        MakeInstance();
    }
    
    //Set gamestate and get objects
    public void Start()
    {
        um = GameObject.Find("Canvas+UIManager").GetComponent<UIManager>();
        highScore = PlayerPrefs.GetFloat("highscore", 0f);
    }

    //Singleton
    private void MakeInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    //Stop game and set highscore if applicable. Display endscreen from UIManager script
    public void GameOver()
    {
        Time.timeScale = 0;
        if (score > highScore)
        {
            PlayerPrefs.SetFloat("highscore", score);
            highScore = score;
            //Does not show submit button if highscore not reached
            um.DisplayEnd(true);
        }
        else
        {
            um.DisplayEnd(false);
        }
    }

    //Change gamestate and hide menu
    //public void PlayGame()
    //{
    //    highScore = PlayerPrefs.GetFloat("highscore", 0f);
    //    PlayerNameStr = "test";
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("gameScene", LoadSceneMode.Single);
        //Reset
        score = 0;
        Time.timeScale = 1;
        //Hide end screen
        um.HideEnd();
    }

    public void submitName()
    {
        PlayerPrefs.SetString("highscoreName", PlayerName.text);
    }

    public void coinCollected()
    {
        score += 3;
    }

    public float getScore()
    {
        return score;
    }
	
    public float getHighScore()
    {
        return highScore;
    }

    public string getHighScoreName()
    {
        return PlayerPrefs.GetString("highscoreName");
    }

	// Update is called once per frame
	void Update () {
        //Add declared points per second to score based on delaTime
        score += pointsPerSec * Time.deltaTime;
    }
}
