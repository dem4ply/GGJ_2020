using UnityEngine;
using System.Collections;

public class BallBounceSound : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject,10.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        AudioSource sound = FindObjectOfType<AudioSource>();
        sound.Play();
    }
}
