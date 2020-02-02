using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour
{
    public float rotationspeed = 1;
    
    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        Camera camara = GetComponentInChildren<Camera>();
        float MouseX = Input.GetAxis("Mouse X") * rotationspeed;
        float MouseY = Input.GetAxis("Mouse Y") * rotationspeed;
        transform.localRotation = transform.localRotation * Quaternion.Euler(0, MouseX, 0);
        camara.transform.localRotation = camara.transform.localRotation * Quaternion.Euler(-MouseY, 0, 0);
    }
}
