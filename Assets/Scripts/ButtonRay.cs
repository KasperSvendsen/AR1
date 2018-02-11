using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonRay : MonoBehaviour
{

    private GameObject millennium;
    private GameObject interceptor;
    public ParticleSystem explosion;

    private float rayLength;
    private bool shoot;
    private Ray ray;
    private Ray ray2;
    private Material material;

    private float leftCannon;

    // Use this for initialization
    void Start()
    {
        millennium = GameObject.Find("Millennium Falcon");
        interceptor = GameObject.Find("Interceptor");

        shoot = false;
        explosion.Pause();
        rayLength = 10;
        leftCannon = 0.07f;

    }

    // Update is called once per frame
    void Update()
    {
        //Local positions of cameras
        Vector3 leftLocalPos = new Vector3((millennium.transform.position.x - leftCannon), millennium.transform.position.y, millennium.transform.position.z);

        //Vector3 rightLocalPos =

        //World positions of cameras
        Vector3 leftWorldPos = millennium.transform.position + millennium.transform.rotation * leftLocalPos;

        //center cannon into scene view
        ray.origin = millennium.transform.position; 
        ray.direction = millennium.transform.forward;

        Debug.DrawRay(ray.origin, ray.direction * rayLength);

        //left and right front cannons into scene view
        ray2.origin = leftWorldPos;
        ray2.direction = millennium.transform.forward;

        Debug.DrawRay(ray.origin, ray.direction * rayLength);


        //shoot if space is pressed
        if (Input.GetKeyDown("space"))
        {
            //draw line
            shoot = true;

            RaycastHit hit;
        
            //check collision
            if (Physics.Raycast(ray.origin, ray.direction, out hit, rayLength))
            {
                //Play explosion at collision point
                explosion.transform.position = hit.point;
                explosion.Play();
            }
        }else
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
            GL.End();
        }
        
    }
}
