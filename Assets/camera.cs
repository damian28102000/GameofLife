using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float speed = 50.0f; 
    public float camSens = 0.25f; 
    private Vector3 lastMouse = new Vector3(255, 125, 255); 

    void Update()
    {
        // Euler angles logic - mouse 
        lastMouse = Input.mousePosition - lastMouse;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x -lastMouse.y * camSens, transform.eulerAngles.y + lastMouse.x * camSens, 0);
        lastMouse = Input.mousePosition;

        // Transform camera
        Vector3 p = GetBaseInput();
        p = p * speed * Time.deltaTime;
        transform.Translate(p);

        if(Input.GetKey("escape"))
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    private Vector3 GetBaseInput()
    {
        Vector3 velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity += new Vector3(1, 0, 0);
        }
        return velocity;
    }
}
