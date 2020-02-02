using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeDisplayer : MonoBehaviour {

    Text Timetext;
    LevelManager levelmanager;

    // Use this for initialization
    void Start()
    {
        Timetext = GetComponent<Text>();
        levelmanager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Timetext.text = "Time: " + levelmanager.TimetillNextlevel.ToString("0.00");
    }
}
