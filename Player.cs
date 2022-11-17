using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float speed=5;
    public Camera cam;
    Ray ray;
    RaycastHit hit;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public RaycastHit getHit()
    {
        return hit;
    }
    // Update is called once per frame
    void Update()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        
        Physics.Raycast(ray, out hit);

        Debug.Log(hit.point.x+","+hit.point.y+"," + hit.point.z);

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward*speed,ForceMode.Force);            
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-Vector3.forward * speed, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-Vector3.right * speed, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * speed, ForceMode.Force);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up*6, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            rb.AddForce(rb.velocity.normalized*30, ForceMode.Impulse);
        }

        transform.LookAt(hit.point);
    }
}
