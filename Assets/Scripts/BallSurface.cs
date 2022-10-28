using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallSurface : MonoBehaviour
{
    public GameObject floor;
    public float score = 0f;
    public TMP_Text displayText;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0.1f, 0, 0.1f);
        
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position.Set(0,
            floor.transform.position.y + 0.17501f
            , 0);
        
    }
    void Awake()
    {
        //print("Ball awake");
        if (displayText == null)
        {
            displayText = GameObject.FindWithTag("scoreDisplay").GetComponent<TMP_Text>();
        }
        if (floor == null)
        {
            floor = GameObject.FindWithTag("Floor");//GetComponent<TMP_Text>();
        }

        //score = GameObject.FindWithTag("DZ").GetComponent<DZscript>().saveScore; //My save score attempt
    }
    private void OnCollisionEnter(Collision collision)
    {
        score += collision.gameObject.GetComponent<BounceBackBumper>().scoreValue; //Increase score
        //score += collision.gameObject.GetComponent<ExtraBounceBack>().scoreValue;

        displayText.text = "Score: " + score;
    }
    public void IncreaseScore()
    {
        score += 100;
        displayText.text = "Score: " + score;
    }
}
