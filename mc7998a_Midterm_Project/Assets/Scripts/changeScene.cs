using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class changeScene : MonoBehaviour {
    public void loadScene() { 
        SceneManager.LoadScene("gameWorld");
    }

    public void loadHome() {
        SceneManager.LoadScene("mainMenu"); 
    }
}
