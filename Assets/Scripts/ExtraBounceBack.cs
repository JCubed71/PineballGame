using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
public class ExtraBounceBack : MonoBehaviour
{
    public float bounceForce = 400f;
    public float scoreValue = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private async void OnCollisionEnter(Collision collision)
    {


        if (collision.transform.CompareTag("Ball"))
        {
            collision.rigidbody.AddExplosionForce(
                bounceForce,
                collision.contacts[0].point, 15);

            GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            await Task.Delay(200);
            GetComponent<Renderer>().material.DisableKeyword("_EMISSION");

            GameObject.Find("Ball").GetComponent<BallSurface>().IncreaseScore();

        }
    }
}

