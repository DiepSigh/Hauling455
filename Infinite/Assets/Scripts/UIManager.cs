using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    public Text ScoreText;
    public float pointsPerSec;

    public Text EndScore;
    public Text EndHighScore;
    public Text EndName;

    public GameObject Submit;
    public GameObject InputName;

    gameManager gm;
    public GameObject end;

    //Attempt to make instance on awake
    void Awake()
    {
        MakeInstance();
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

    // Use this for initialization
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();
    }
    void Update()
    {
        //Display score after rounding to avoid decimals
        ScoreText.text = Mathf.Round(gm.getScore()).ToString();
    }

    public void DisplayEnd(bool submit)
    {
        //Displays end screen and if score is higher than highscore, show inputbox and submit button
        end.SetActive(true);
        EndScore.text = "Your Score: " + Mathf.Round(gm.getScore());
        EndHighScore.text = "High-Score: " + Mathf.Round(gm.getHighScore());

        if (submit)
        {
            Submit.SetActive(true);
            InputName.SetActive(true);
        }
        else
        {
            EndName.text = gm.getHighScoreName();
            Submit.SetActive(false);
            InputName.SetActive(false);
        }
    }

    public void HideEnd()
    {
        end.SetActive(false);
    }
}
