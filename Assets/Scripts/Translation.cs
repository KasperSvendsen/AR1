using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Translation : MonoBehaviour {

    private GameObject spaceShuttle;
    private GameObject earth;
    private GameObject nose;

    private Vector3 posInEarth;

    public string nosePosition;
    public string hemisphere;

    // Use this for initialization
    void Start () {
        spaceShuttle = GameObject.Find("SpaceShuttle");
        earth = GameObject.Find("Earth");
        nose = GameObject.Find("Nose");
    }
	
	// Update is called once per frame
	void Update () {

        //Nose's transform matrix and the spaceshuttle's model matrix for going to the position in world coordinates
        Matrix4x4 noseMatrix = Matrix4x4.TRS(nose.transform.localPosition, nose.transform.localRotation, nose.transform.localScale);
        Matrix4x4 spaceShuttleMatrix = spaceShuttle.transform.localToWorldMatrix; //the model matrix for the spaceShuttle

        //The inverse earth model matrix for going back to earth coordinates
        Matrix4x4 inverseEarthMatrix = earth.transform.worldToLocalMatrix;

        //Transformation matrix
        Matrix4x4 transformationMatrix = inverseEarthMatrix * spaceShuttleMatrix;

        //Going to transform matrix in earth coordinates
        Matrix4x4 posMatrixInEarth =  transformationMatrix * noseMatrix;

        //Position vector
        posInEarth = posMatrixInEarth.GetColumn(3);

        //print("Pos: " + posMatrixInEarth.GetColumn(3));

        nosePosition = "Local position: " + posInEarth.x.ToString() + ", " + posInEarth.y.ToString() + ", " + posInEarth.z.ToString();


        //Check wether nose is above the earth and which hemisphere
        if (Mathf.Abs(posInEarth.x) < 0.45f && Mathf.Abs(posInEarth.z) < 0.45f && posInEarth.y < 0.4f){ //cylindrical boundaries
            if (posInEarth.z > 0)
            {
                hemisphere = "Hemisphere: North";
            } else if(posInEarth.z < 0){
                hemisphere = "Hemisphere: South";
            }

        }else
        {
            hemisphere = "Not above earth";
        }


    }

    
    void OnGUI()
    {
        GUI.color = Color.red;
        GUI.Label(new Rect(10, 10, 500, 100), hemisphere);
        GUI.Label(new Rect(10,25, 500,100), nosePosition);

    }

    
}
