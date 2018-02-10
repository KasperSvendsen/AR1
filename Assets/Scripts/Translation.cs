using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Translation : MonoBehaviour {

    private GameObject spaceShuttle;
    private GameObject earth;
    private GameObject nose;

    private Vector3 posInEarth;
    public Text nosePosition;

    // Use this for initialization
    void Start () {
        spaceShuttle = GameObject.Find("SpaceShuttle");
        earth = GameObject.Find("Earth");
        nose = GameObject.Find("Nose");
        setNosePositiontext();
    }
	
	// Update is called once per frame
	void Update () {

        //Position of quad and the spaceshuttle's matrix for going to the position in world coordinates
        Vector3 nosePos = nose.transform.localPosition;
        Matrix4x4 spaceShuttleMatrix = spaceShuttle.transform.localToWorldMatrix; //the model matrix for the spaceShuttle

        //The inverse earth matrix for going back to earth coordinates
        Matrix4x4 inverseEarthMatrix = earth.transform.worldToLocalMatrix;

        //Transformation matrix
        Matrix4x4 transformationMatrix = inverseEarthMatrix * spaceShuttleMatrix;

        //Going to position in earth coordinates
        posInEarth =  transformationMatrix * nosePos;

        //print("Pos: " + posInEarth.x);

        setNosePositiontext();

        print(earth.transform.localToWorldMatrix.GetColumn(2));

        //Check wether nose is above the earth -- wrong numbers!!!
        if (posInEarth.x < 1 && posInEarth.z < 1 && posInEarth.y < 0.05){
            if (posInEarth.x < 1)
            {
                print("Hemisphere_ North");
            } else if(posInEarth.x > 1){
                print("Hemisphere: South");
            }
            
        }




    }   

    //Method for setting the text
    void setNosePositiontext()
    {
        nosePosition.text = "Local position: " + posInEarth.x.ToString() + ", " + posInEarth.y.ToString() + ", " + posInEarth.z.ToString();
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
}
