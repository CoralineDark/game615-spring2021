using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dollWallScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject playerInfo; 
    private int numDolls; 
    bool playerWon; 
    void Start()
    {
        playerWon = false; 
        playerInfo = GameObject.Find("player 1"); 

    }

    // Update is called once per frame
    void Update()
    {
        numDolls = playerInfo.gameObject.GetComponent<playerScripts>().dolls; 

        if (numDolls >= 5) { 
            playerWon = true; 
        }
    }

    private void OnTriggerEnter(Collider other) {
        print("collission detected"); 
        if (other.CompareTag("fired")&& numDolls >= 5) { 
            print("You Won!"); 
            Destroy(other.gameObject); 
            Destroy(gameObject); 
        }
    }

    private void OnGUI()
	{
		if (playerWon) {
			GUI.Label(new Rect(250, 250, 200, 200), "You've collected all the dolls! Shoot the exit to leave");
		}
	}
}
