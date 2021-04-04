using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dollWallScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject playerInfo; 
    private int numDolls;
    void Start()
    {
        playerInfo = GameObject.Find("player 1"); 

    }

    // Update is called once per frame
    void Update()
    {
        numDolls = playerInfo.gameObject.GetComponent<playerScripts>().dolls; 
    }

    private void OnTriggerEnter(Collider other) {
        print("collission detected"); 
        if (other.CompareTag("fired")&& numDolls >= 10) { 
            Destroy(other.gameObject); 
            Destroy(gameObject); 
        }
    }


}
