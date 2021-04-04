using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeUI : MonoBehaviour
{
    // Start is called before the first frame update
    public void closeControls() {
        GameObject controlsCanvas = GameObject.Find("controls"); 
        controlsCanvas.gameObject.SetActive(false);
        GameObject playerControls = GameObject.Find("player 1"); 
        playerControls.gameObject.GetComponent<playerScripts>().startMenuOpen = false;
    }

    public void openControls() {
        GameObject controlsCanvas = GameObject.Find("controls"); 
        controlsCanvas.gameObject.SetActive(true);
    }
}
