using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleDriverScript : MonoBehaviour {

    public float hitPower = 10000f; //was 1000
    public float paddleDamper = 200f; //Was 10
    public float upPosition = 200f; //was 45
    public float downPosition = 0f;

    public HingeJoint hinge;
    public string inputName;

	// Use this for initialization
	void Start () {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
		
	}
	
	// Update is called once per frame
	void Update () {
        JointSpring spring = new JointSpring
        {
            spring = hitPower,
            damper = paddleDamper
        };
        spring.targetPosition =Input.GetKey(KeyCode.Space) ? upPosition : downPosition; //If true go to up position, if false go to down position
        hinge.spring = spring; //hinge.spring (one in the inspector) is assigned the spring that is created with 'new' above in this function
        hinge.useLimits = true;	
	}
}
