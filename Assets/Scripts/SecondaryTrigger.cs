using UnityEngine;
using System.Collections;

public class SecondaryTrigger : MonoBehaviour
{
    Collider ExpectedCollider;
	
    public void ExpectCollider(Collider collider)
    {
        ExpectedCollider = collider;        
    }

    void OnTriggerEnter(Collider othercollider)
    {        
        if( othercollider == ExpectedCollider)
        {
            ScoreKeeper scorekeep = FindObjectOfType<ScoreKeeper>();            
            scorekeep.IncrementScore(1);            
        }
    }
}
