using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScripts : MonoBehaviour
{

    public float speed = 10; 
    // Start is called before the first frame update
    void Start()
    {
        print("I exist!");
        //transform.forward = Vector.X; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=  transform.forward * speed * Time.deltaTime; 
    }

}


