using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{//The camera script that makes the camera follow the player

    public Transform target;
    Camera mycam;
    public float m_speed = 0.1f; //the speed of the camera
    public float cameraZoom = 70f;

    // Use this for initialization
    void Start()
    {
        mycam = GetComponent<Camera>();


    }
 
	
	// Update is called once per frame
	void Update ()
    {

        mycam.orthographicSize = (Screen.height / cameraZoom); // (Increased number = closer camera)
        //mycam.orthographicSize = Screen.width / (((Screen.width / Screen.height) * 2) * 32);
        if (target)
        {   //moves the camera
            transform.position = Vector3.Lerp(transform.position, target.position, m_speed) + new Vector3(0, 0, -10); //avoids the camera from moving in z-position 
        }

	}
}
