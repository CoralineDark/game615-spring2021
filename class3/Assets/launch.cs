﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.useGravity = true; 
            rb.AddForce(transform.forward * 1000.0f);
        } 
    }
}
