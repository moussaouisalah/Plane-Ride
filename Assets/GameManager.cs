using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject plane;
    public GameObject gameOverCanvas;
    public GameObject ScoreCanvas;
    public GameObject agameOverCanvas;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        ScoreCanvas.SetActive(false);
        agameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (plane.GetComponent<PlayerMovement>().Destroyed)
            GameOver();
    }

    void GameOver()
    {
        Invoke("GameOverScreen", 1f);
    }

    public void GameOverScreen()
    {
        agameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Play()
    {
        gameOverCanvas.SetActive(false);
        ScoreCanvas.SetActive(true);
        Time.timeScale = 1;
    }
}
