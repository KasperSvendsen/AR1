using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRay2 : MonoBehaviour
{ 
    private GameObject millennium;

    private float rayLength;

    private float leftPosX;
    private float leftPosZ;
    private float rightPosX;
    private float rightPosZ;
    private float topPosY;

    private bool shoot;

    private Ray ray;
    private Ray ray2;
    private Ray ray3;
    private Material material;

    public float pitch;
    public float yaw;


    // Use this for initialization
    void Start()
    {
        millennium = GameObject.Find("Millennium Falcon");

        shoot = false;
        rayLength = 10;

        pitch = 1;
        yaw = 1;


        //Positions of cannons
        leftPosX = -0.6f;
        leftPosZ = 4.4f;
        rightPosX = 0.6f;
        rightPosZ = 4.4f;
        topPosY = 2.5f;

    }

    // Update is called once per frame
    void Update()
    {
        //Local positions and world position of left cannon
        Vector3 leftLocalPos = new Vector3(leftPosX, 0, leftPosZ);
        Vector3 leftWorldPos = millennium.transform.position + millennium.transform.rotation * leftLocalPos;


        //Local positions and world position of right cannon
        Vector3 rightLocalPos = new Vector3(rightPosX, 0, rightPosZ);
        Vector3 rightWorldPos = millennium.transform.position + millennium.transform.rotation * rightLocalPos;


        //Local positions and world position of right cannon
        Vector3 topLocalPos = new Vector3(0, topPosY, 0);
        Vector3 topWorldPos = millennium.transform.position + millennium.transform.rotation * topLocalPos;


        //left cannon into scene view
        ray.origin = leftWorldPos;
        ray.direction = millennium.transform.forward;
        Debug.DrawRay(ray.origin, ray.direction * rayLength);

        //right cannon into scene view
        ray2.origin = rightWorldPos;
        ray2.direction = millennium.transform.forward;
        Debug.DrawRay(ray2.origin, ray2.direction * rayLength);

        //top cannon into scene view
        Quaternion cannonRotation = Quaternion.Euler(new Vector3(pitch, yaw, 0));
        Vector3 cannonDirection = cannonRotation * millennium.transform.forward;
        ray3.origin = topWorldPos;
        ray3.direction = cannonDirection;
        Debug.DrawRay(ray3.origin, ray3.direction * rayLength);


        //shoot if space is pressed
        if (Input.GetKeyDown("space"))
        {
            //draw line
            shoot = true;
            print("shoot");

            RaycastHit hit;

            //check collision
            if (Physics.Raycast(ray.origin, ray.direction, out hit, rayLength))
            {

            }
        }
        else
        {
            //stop drawing line
            shoot = false;
        }
    }




    void OnRenderObject()
    {
        //draw into game view if space is pressed
        if (shoot == true)
        {
            if (material == null)
            {
                material = new Material(Shader.Find("Hidden/Internal-Colored"));
            }
            material.SetPass(0);

            GL.Begin(GL.LINES);
            GL.Color(Color.red);
            GL.Vertex(ray.origin);
            GL.Vertex(ray.origin + ray.direction * rayLength);
            GL.Vertex(ray2.origin);
            GL.Vertex(ray2.origin + ray2.direction * rayLength);
            GL.Vertex(ray3.origin);
            GL.Vertex(ray3.origin + ray3.direction * rayLength);
            GL.End();


        }

    }
}


