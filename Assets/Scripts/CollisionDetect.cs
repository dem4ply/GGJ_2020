using UnityEngine;
using System.Collections;

public class CollisionDetect : MonoBehaviour
{

    // Use this for initialization
    public int scorevalue = 1;
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision collision)
    {
        ScoreKeeper scorekeep= FindObjectOfType<ScoreKeeper>();
        scorekeep.IncrementScore(scorevalue);
    }
}
