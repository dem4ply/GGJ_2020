using UnityEngine;
using System.Collections;

public class BallLauncher : MonoBehaviour
{
    public GameObject basketball;
    public float velocity = 5;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Camera camara = GetComponent<Camera>();
            GameObject instanceball = Instantiate(basketball);
            instanceball.transform.position = transform.position;
            Rigidbody rb = instanceball.GetComponent<Rigidbody>();
            rb.velocity = camara.transform.rotation * Vector3.forward * velocity;
        }

    }
}
