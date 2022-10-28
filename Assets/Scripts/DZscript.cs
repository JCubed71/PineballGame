using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DZscript : MonoBehaviour
{
    public GameObject newBall;
    public int numLives;
    //public float saveScore = 0; // My save score attempt
    // Start is called before the first frame update
    void Start()
    {
        
    }

 
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Rigidbody>().CompareTag("Ball"))
        {
            //saveScore = collision.gameObject.GetComponent<BallSurface>().score; //My save score attempt
            //print("Save score is " + saveScore);
            Destroy(collision.gameObject);
            GameObject.Find("GameManager").GetComponent<scoreSaver>().LoseLife();
            numLives = GameObject.Find("GameManager").GetComponent<scoreSaver>().lives;
            if(numLives >= 0)
            {
                Instantiate(newBall);
            }
            
            
            
        }
    }
    public void RestartGame()
    {
        Instantiate(newBall);
        print("restarting");
        //TMP_Text.FindWithTag("lifeSprite").enabled = true; //old way
        GameObject.Find("GameManager").GetComponent<scoreSaver>().SetLifeSpritesStatus(true); // new way
        print("part 2");
        GameObject.Find("GameManager").GetComponent<scoreSaver>().SetLives(3);
        print("part 3");
        GameObject.Find("GameManager").GetComponent<scoreSaver>().savedScore = 0f;
        print("part 4");
        GameObject.FindWithTag("Ball").GetComponent<BallSurface>().score = 0f;
        print("part 5");

        GameObject.Find("GameManager").GetComponent<scoreSaver>().gameOverButton.SetActive(false);
        print("part 6");
        //TMP_Text.Find("highscoreText").enabled = false; //old way
        GameObject.Find("GameManager").GetComponent<scoreSaver>().SetHighscoreStatus(false); //new way
        print("part 7");
        GameObject.FindWithTag("Ball").GetComponent<BallSurface>().displayText.text = "Score: " + 0;
    }
}
