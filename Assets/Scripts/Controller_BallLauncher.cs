using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_BallLauncher : MonoBehaviour
{
    public GameObject basketball;
    public float launchrate;
    private float nextlaunch;
    public float speed = 10;

   
    // Update is called once per frame
    void Update()
    {
        OVRInput.Controller activeController = OVRInput.GetActiveController();

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && Time.time>nextlaunch)
        {
            //OVRHand righthand = GetComponent<OVRHand>();
            Quaternion rot = OVRInput.GetLocalControllerRotation(activeController);

            nextlaunch = Time.time + launchrate;
            GameObject instanceball = Instantiate(basketball, gameObject.transform.position, gameObject.transform.rotation);
            Rigidbody rbball = instanceball.GetComponent<Rigidbody>();
            rbball.velocity = rot * Vector3.forward * speed;
            //rbball.velocity =  Vector3.forward * speed;
        }
    }
}
