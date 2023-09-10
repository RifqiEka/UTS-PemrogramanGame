using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;
    public Text scoreText;
    public Text livesText;
    public bool gameover;
    public GameObject gameoverpanel;
    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int changeInLives)
    {
        lives += changeInLives;

        //Check for no lives
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }
        livesText.text = "Lives: " + lives;
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    void GameOver()
    {
        gameover = true;
        gameoverpanel.SetActive(true);
    }
    public void playagain()
    {
        SceneManager.LoadScene("level1");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
