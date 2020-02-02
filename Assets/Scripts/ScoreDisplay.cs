using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    Text scoretext;

	// Use this for initialization
	void Start ()
    {
        scoretext = GetComponent<Text>();
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        ScoreKeeper scorekeep = FindObjectOfType<ScoreKeeper>();
        
        scoretext.text = "Score: " + scorekeep.score;
	
	}
}
