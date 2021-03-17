using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{

    public float speed; 
    public float clockwise; 
    public float counterClockwise; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() { 
        Rigidbody rb = GetComponent <Rigidbody>(); 
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow )) {
            rb.velocity=transform.forward *speed; 
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow )) {
             rb.velocity=transform.forward *0; 
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow )) {
            transform.Rotate(0, Time.deltaTime * counterClockwise, 0);  
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow )) {
             rb.velocity=-transform.forward *speed; 
        }
        else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow )) {
             rb.velocity=-transform.forward *0; 
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow )) {
            transform.Rotate(0, Time.deltaTime * clockwise, 0); 
        }

    }
}