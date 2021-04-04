using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletWallScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        print("collission detected"); 
        if (other.CompareTag("fired")) { 
            print("we hit a bullet barrior!"); 
            Destroy(other.gameObject); 
            Destroy(gameObject); 
        }
    }
}
