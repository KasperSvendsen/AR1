using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingChecker : MonoBehaviour {

    private GameObject spaceShuttle;
    private GameObject landingStrip;
    private GameObject quad;
    private Vector3 shuttlePos;
    private Vector3 landingPos;

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

        //shuttlePos = spaceShuttle.transform.localPosition;
        //landingPos = landingStrip.transform.localPosition;

        //print(Vector3.Dot(shuttlePos, landingPos));

        shuttleFor = spaceShuttle.transform.forward;
        landingFor = landingStrip.transform.forward;

        shuttleRight = spaceShuttle.transform.right;
        landingRight = landingStrip.transform.right;

        forwardDir = Vector3.Dot(shuttleFor, landingFor);
        rightDir = Vector3.Dot(shuttleRight, landingRight);

        print(forwardDir);
        AngleToColor(forwardDir, rightDir);



        //Matrix4x4 shuttleMatrix = T(spaceShuttle.transform.position.x, spaceShuttle.transform.position.y, spaceShuttle.transform.position.z);
        //Matrix4x4 landingMatrix = T(landingStrip.transform.position.x, landingStrip.transform.position.y, landingStrip.transform.position.z);

        //print(shuttleMatrix * landingMatrix);

        //Vector3 forwardShuttle = shuttleMatrix.GetColumn(3);
        //Vector3 rightShuttle = shuttleMatrix.GetColumn(1);


        //Vector3 forwardLanding = landingMatrix.GetColumn(3);
        //Vector3 rightLanding = landingMatrix.GetColumn(1);

        /*
         * METHOD FOR CHANGING COLOR OF QUAD
        quad.GetComponent<Renderer>().material.color = Color.green;
        */


        //suttlePos = Vector3.Normalize(spaceShuttle.transform.position);
        //landingPos = Vector3.Normalize(landingStrip.transform.position);



    }


    void AngleToColor(float fowardAngle, float rightAngle)
    {
        float absForwardAngle = Mathf.Abs(fowardAngle);
        float absRightAngle = Mathf.Abs(rightAngle);


        if (absForwardAngle > .9 && absRightAngle > .9)
        {
            quad.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if (absForwardAngle > .8 && absRightAngle > .8)
        {
            quad.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            quad.GetComponent<Renderer>().material.color = Color.red;
        }
    }

}
