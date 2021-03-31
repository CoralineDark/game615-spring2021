using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    //camera movement 
    public float speedHorizontal;
    public float speedVertical;  
    public float yaw = 0.0f; 
    public float pitch = 0.0f; 

    //character movement
    private Rigidbody rb; 
    public float speed; 
    public float clockwise; 
    public float ccwise; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>(); 
    }

    // Update is called once per frame
    void Update() { 
        yaw += speedHorizontal * Input.GetAxis("Mouse X");
        pitch -= speedVertical * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        float moveHorizontal = Input.GetAxis("Horizontal"); 
        float moveVertical = Input.GetAxis("Vertical"); 
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement; 
    }
}
