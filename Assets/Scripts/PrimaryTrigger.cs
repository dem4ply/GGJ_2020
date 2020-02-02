using UnityEngine;
using System.Collections;

public class PrimaryTrigger : MonoBehaviour {
    
    void OnTriggerEnter(Collider other)
    {
        SecondaryTrigger trigger = GetComponentInChildren<SecondaryTrigger>();
        trigger.ExpectCollider(other);        
    }
}
