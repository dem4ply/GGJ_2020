using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScoreDisplayer : MonoBehaviour
{

    Text scoretext;

    // Use this for initialization
    void Start()
    {
        scoretext = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        ScoreAbsorber scorekeep = FindObjectOfType<ScoreAbsorber>();

        scoretext.text = "Score: " + scorekeep.score;

    }
}
