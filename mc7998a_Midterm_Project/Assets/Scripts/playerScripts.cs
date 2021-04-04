using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class playerScripts : MonoBehaviour
{
    public float speed; 
    public float clockwise; 
    public float counterClockwise; 
    public GameObject bulletPrefab; 
    private GameObject player; 
    public int bullets = 0;
    public int dolls = 0;  
    private float timer; 
    private bool guiLabelTrigger;
    public bool startMenuOpen;
    private GameObject mazeSolution;
    public Renderer rend;
    private bool playerWon; 
    // Start is called before the first frame update
    void Start()
    {
        playerWon = false; 
        player = GameObject.Find("player 1"); 
        int starterBullets = Random.Range(0,4); 
        bullets += starterBullets; 
        dolls = 0;
        timer = 20; 
        startMenuOpen = true; 
        mazeSolution = GameObject.Find("mazeSolution");
        rend = mazeSolution.GetComponent<Renderer>();
        rend.enabled = false; 
    }

    // Update is called once per frame
    void Update() {
        if (startMenuOpen) 
            startMenu(); 
        else {
            if (Input.GetKeyDown(KeyCode.Space) && bullets > 0) {
                SpawnBullets(); 
                bullets--;   
            }
            Rigidbody rb = GetComponent <Rigidbody>(); 
            if (Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow )) {
                transform.Translate(0, 0, speed*Time.deltaTime); 
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow )) {
                transform.Rotate(0, Time.deltaTime * counterClockwise, 0);  
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow )) {
                transform.Translate(0, 0, -speed*Time.deltaTime); 
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow )) {
                transform.Rotate(0, Time.deltaTime * clockwise, 0); 
            }
            if (Input.GetKeyDown (KeyCode.LeftShift)) {
                speed *= 2;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift)) {
                speed /= 2; 
            }
        }
        if (dolls >= 10) {
            rend.enabled = true;
        }
    }

    public void SpawnBullets() { 
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation); 
        bullet.transform.LookAt(player.transform); 
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("bullet")) {
            print("we have collected a bullet");
            bullets++; 
            Destroy(other.gameObject);
             
        }

        if (other.CompareTag("doll")) {
            print("we have collected a doll"); 
            dolls++;
            Destroy(other.gameObject); 
        }

        if (other.name == "noFlyZone") {
            SceneManager.LoadScene("gameWorld");
        }

        if (other.name == "gameWon") {
            playerWon = true; 
        }
    }

    public void startMenu() {
        timer -= Time.deltaTime; 
        if (timer < 0) {
            GameObject controlsCanvas = GameObject.Find("controls"); 
            controlsCanvas.gameObject.SetActive(false);
            startMenuOpen = false;
        } 
    }

    public GUIStyle customGuiStyle; 
    public GUIStyle customGuiStyle2;
    private void OnGUI() {
        if (dolls >= 10) {
            GUI.Label(new Rect(125,200,200,200), "You have found 10 crewmates. Congratulations! You may now head to the exit.", customGuiStyle);
        }
        else {
            GUI.Label(new Rect(125,200,200,200), "You have " + bullets + " bullets.", customGuiStyle);
        }
        if (playerWon) {
            GUI.Label(new Rect(Screen.width/2,Screen.height/2,200,200), "You Won!", customGuiStyle2);
        }
        GUI.Label(new Rect(125,250,200,200), "You have " + dolls + " crewmates.", customGuiStyle);
    }
}
