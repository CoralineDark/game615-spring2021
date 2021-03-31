using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player 1"); 
        int starterBullets = Random.Range(0,5); 
        bullets += starterBullets; 
        dolls = 0;
        timer = 30;  
    }

    // Update is called once per frame
    void Update() {
        timer -= Time.deltaTime; 
        if (timer < 0) {
            bullets++; 
            timer = 30; 
        }
        
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
    }

    private void OnGUI() {
        GUI.Label(new Rect(250,300,200,200), "You have " + bullets + " bullets.");
        GUI.Label(new Rect(250,350,200,200), "You have " + dolls + " dolls.");
        return; 
	}
}
