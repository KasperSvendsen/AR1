using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonRay : MonoBehaviour
{

    private GameObject millennium;
    private GameObject interceptor;

    private float rayLength;
    private Ray ray;
    private Material material;

    public Button shootButton;


    // Use this for initialization
    void Start()
    {
        millennium = GameObject.Find("Millennium Falcon");
        interceptor = GameObject.Find("Interceptor");
 
        rayLength = 10;

        Button btn = shootButton.GetComponent<Button>();
        btn.GetComponentInChildren<Text>().text = "Shoot";
        btn.onClick.AddListener(TaskOnClick);

    }

    // Update is called once per frame
    void Update()
    {

        //Vector3 worldPos = millennium.transform.position + millennium.transform.rotation * millennium.transform.localPosition;


        ray.origin = millennium.transform.position; 
        ray.direction = millennium.transform.forward;

        //draw into scene view
        Debug.DrawRay(ray.origin, ray.direction * rayLength);

    }


    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        Physics.Raycast(ray.origin, ray.direction * rayLength);


        
    }

    void OnRenderObject()
    {
        //draw into game view
        if (material == null)
        {
            material = new Material(Shader.Find("Hidden/Internal-Colored"));
            material.SetPass(0);

            GL.Begin(GL.LINES);
            GL.Color(Color.red);
            GL.Vertex(ray.origin);
            GL.Vertex(ray.origin + ray.direction * rayLength);
            GL.End();
        }
    }
}
