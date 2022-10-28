using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreSaver : MonoBehaviour
{
    //public GameObject ball;
    public float savedScore = 0;
    public int lives = 3;
    public float highestScore = 0;
    public GameObject ballSprite3;
    public GameObject ballSprite2;
    public GameObject ballSprite1;
    public GameObject gameOverButton;
    public TMP_Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetLives(int lives_)
    {
        lives = lives_;
    }
    // Update is called once per frame
    void Update()
    {
        if(lives >= 0) //while game isn't over
        {
            if (GameObject.FindWithTag("Ball").GetComponent<BallSurface>().score < savedScore)
            {
                GameObject.FindWithTag("Ball").GetComponent<BallSurface>().score = savedScore;
            }
            else
            {
                savedScore = GameObject.FindWithTag("Ball").GetComponent<BallSurface>().score;
            }
        }
        
    }
    public void LoseLife()
    {
        lives -= 1;
        if (lives == 2)
        {
            ballSprite3.SetActive(false);
        }
        if (lives == 1)
        {
            ballSprite2.SetActive(false);
        }
        if (lives == 0)
        {
            ballSprite1.SetActive(false);
        }

        if (lives < 0)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        if(savedScore > highestScore)
        {
            highestScore = savedScore;
        }
        print("Game Over!");
        gameOverButton.SetActive(true);
        print("Game over part2");
        highScoreText.enabled = true;
        highScoreText.gameObject.SetActive(true);

        print("Game over part 3");
        highScoreText.text = "HighScore: " + highestScore;
        print("Game over part 4");
    }
    public void SetLifeSpritesStatus(bool status)
    {
        if (status == true)
        {
            ballSprite1.SetActive(true);
            ballSprite2.SetActive(true);
            ballSprite3.SetActive(true);
        }
        if(status == false)
        {
            ballSprite1.SetActive(false);
            ballSprite2.SetActive(false);
            ballSprite3.SetActive(false);
        }

    }
    public void SetHighscoreStatus(bool status)
    {
        if(status == true)
        {
            highScoreText.enabled = true;
        }
        if(status == false)
        {
            highScoreText.enabled = false;
        }
    }
}
