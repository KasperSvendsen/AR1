using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingChecker : MonoBehaviour {

    private GameObject spaceShuttle;
    private GameObject landingStrip;
    private GameObject quad;

    private Vector3 shuttleFor;
    private Vector3 landingFor;

    private Vector3 shuttleRight;
    private Vector3 landingRight;

    private float forwardDir;
    private float rightDir;


    // Use this for initialization
    void Start () {
        spaceShuttle = GameObject.Find("SpaceShuttle");
        landingStrip = GameObject.Find("LandingStrip");
        quad = GameObject.Find("Quad");

	}
	
	// Update is called once per frame
	void Update () {

        //forward vectors: Blue axis: Z
        shuttleFor = spaceShuttle.transform.forward;
        landingFor = landingStrip.transform.forward;

        //Right vectors: Red axis: x
        shuttleRight = spaceShuttle.transform.right;
        landingRight = landingStrip.transform.right;


        /*Dot product: For normalized vectors Dot returns: 
                 1: if they point in exactly the same direction, 
                -1: if they point in completely opposite directions
                 0: if the vectors are perpendicular
        */
        forwardDir = Vector3.Dot(shuttleFor, landingFor); 
        rightDir = Vector3.Dot(shuttleRight, landingRight); 


        //print("For: " + forwardDir);
        //print("Right: " + rightDir);

        //Determine color of quad
        AngleToColor(forwardDir, rightDir);





    }

    void AngleToColor(float forwardAngle, float rightAngle)
    {


        if ((forwardAngle >= 0.9 || forwardAngle <= -0.9) && (rightAngle >= 0.9 || rightAngle <= -0.9)) //forward and right align
        {
            print("Both align");
            quad.GetComponent<Renderer>().material.color = Color.green;
        }

        else if ((forwardAngle >= 0.9 || forwardAngle <= -0.9) && (rightAngle < 0.9 || rightAngle > -0.9)){ //forward align and right does not
            print("Only forward align");
            //????
        }

        else if ((forwardAngle < 0.9 || forwardAngle > -0.9) && (rightAngle >= 0.9 || rightAngle <= -0.9)) // right align and forward does not
        {
            print("Only right align");
            quad.GetComponent<Renderer>().material.color = Color.yellow;
        }

        else if ((forwardAngle < 0.9 || forwardAngle > -0.9) && (rightAngle < 0.9 || rightAngle > -0.9)) //no one align
        {
            print("No one align");
            quad.GetComponent<Renderer>().material.color = Color.red;
        }

    }


 }
