using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSnowball : MonoBehaviour
{
    public GameObject snowballPrefab; 
    private GameObject cameraObj; 
    // Start is called before the first frame update
    void Start()
    {
        cameraObj = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { 
            GameObject snowball = Instantiate(snowballPrefab, transform.position, transform.rotation);
            snowball.transform.LookAt(cameraObj.transform);
            //GameObject snowball = Instantiate(snowballPrefab, transform.position, transform.rotation); 
            //Vector3 vectorToTarget = cameraObj.transform.position - transform.position;
            //vectorToTarget = vectorToTarget.normalized;
            //snowball.transform.forward = vectorToTarget; 
        }
    }
}
