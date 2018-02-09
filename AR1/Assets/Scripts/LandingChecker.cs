using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingChecker : MonoBehaviour {

    private GameObject spaceShuttle;
    private GameObject landingStrip;
    private GameObject quad;
    private Vector3 shuttlePos;
    private Vector3 landingPos;

	// Use this for initialization
	void Start () {
        spaceShuttle = GameObject.Find("SpaceShuttle");
        landingStrip = GameObject.Find("LandingStrip");
        quad = GameObject.Find("Quad");

	}
	
	// Update is called once per frame
	void Update () {
        
        Matrix4x4 shuttleMatrix = T(shuttlePos.x, shuttlePos.y, shuttlePos.z);
        Matrix4x4 landingMatrix = T(landingPos.x, landingPos.y, landingPos.z);

        print(shuttleMatrix * landingMatrix);

        Vector3 forwardShuttle = shuttleMatrix.GetColumn(1);
        Vector3 rightShuttle = shuttleMatrix.GetColumn(3);


        Vector3 forwardLanding = landingMatrix.GetColumn(1);
        Vector3 rightLanding = landingMatrix.GetColumn(3);

        print(shuttleMatrix.GetColumn(0));


        /*
        print("Shuttle: "+forwardShuttle);
        print("Landing: "+forwardLanding);
        */

        /*
         * METHOD FOR CHANGING COLOR OF QUAD
        quad.GetComponent<Renderer>().material.color = Color.green;
        */


        //suttlePos = Vector3.Normalize(spaceShuttle.transform.position);
        //landingPos = Vector3.Normalize(landingStrip.transform.position);



	}

    public static Matrix4x4 T(float x, float y, float z)
    {
        Matrix4x4 m = new Matrix4x4();

        m.SetRow(0, new Vector4(1, 0, 0, x));
        m.SetRow(1, new Vector4(0, 1, 0, y));
        m.SetRow(2, new Vector4(0, 0, 1, z));
        m.SetRow(3, new Vector4(0, 0, 0, 1));

        return m;
    }

    public static Matrix4x4 Basis(float x, float y, float z)
    {
        Matrix4x4 m = new Matrix4x4();

        m.SetRow(0, new Vector4(x, 0, 0, 0));
        m.SetRow(1, new Vector4(0, y, 0, 0));
        m.SetRow(2, new Vector4(0, 0, z, 0));
        m.SetRow(3, new Vector4(0, 0, 0, 1));

        return m;
    }
}
