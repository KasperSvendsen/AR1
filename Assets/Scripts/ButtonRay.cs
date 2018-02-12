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
    private Material material;



    // Use this for initialization
    void Start()
    {
        millennium = GameObject.Find("Millennium Falcon");
        interceptor = GameObject.Find("Interceptor");

        shoot = false;
        explosion.Pause();
        rayLength = 10;

    }

    // Update is called once per frame
    void Update()
    {

        //draw into scene view
        ray.origin = millennium.transform.position; 
        ray.direction = millennium.transform.forward;

        Debug.DrawRay(ray.origin, ray.direction * rayLength);


        //shoot if space is pressed
        if (Input.GetKeyDown("space"))
        {
            //draw line
            shoot = true;

            //information about collision
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
            material.SetPass(0); //activate pass for rendering

            GL.Begin(GL.LINES);
            GL.Color(Color.red);
            GL.Vertex(ray.origin);
            GL.Vertex(ray.origin + ray.direction * rayLength);
            GL.End();
        }
        
    }
}
