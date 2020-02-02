using UnityEngine;
using System.Collections;

public class ScoreAbsorber : MonoBehaviour
{
    public int score;

	// Use this for initialization
	void Start ()
    {
        ScoreKeeper Oldscorekeeper = FindObjectOfType<ScoreKeeper>();
        score = 1;
        if(Oldscorekeeper)
        {
            score = Oldscorekeeper.score;
            Destroy(Oldscorekeeper.gameObject);
        }
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
