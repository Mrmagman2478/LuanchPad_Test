using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Scripts : MonoBehaviour
{
    public Canvas startUI;
    public Canvas hubUI;
    public Canvas endUI;

    int endScore;
    string endType;
    public Text scoreText;
    public Text endTypeText;
    public enum StateOfGame
    {
        start,
        InGame,
        End
    }
    public StateOfGame GameState;

    void Start()
    {
        GameState = StateOfGame.start;
        Time.timeScale = 0;
    }

    void Update()
    {
        if(GameState == StateOfGame.start)
        {
            StartUI();
        }
        else if(GameState == StateOfGame.InGame)
        {
            HubUI();
        }
        else
        {
            EndUI();
        }
    }

    void StartUI()
    {
        startUI.enabled = true;
        hubUI.enabled = false;
        endUI.enabled = false;

        if (Input.GetButtonDown("Start"))
        {
            GameState = StateOfGame.InGame;
            Time.timeScale = 1;
        }
    }
    void HubUI()
    {
        startUI.enabled = false;
        hubUI.enabled = true;
        endUI.enabled = false;
    }

    void EndUI()
    {
        endTypeText.text = endType;
        scoreText.text = "Your Score: " + endScore.ToString();
        startUI.enabled = false;
        hubUI.enabled = false;
        endUI.enabled = true;
        Time.timeScale = 0;

        if (Input.GetButtonDown("Start"))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void getInfo(int score, string WayEnded)
    {
        endScore = score;
        endType = WayEnded;
    }
}
