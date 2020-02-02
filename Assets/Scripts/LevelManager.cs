using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float TimetillNextlevel = 5.0f;

	// Use this for initialization
	void Start ()
    {
     
	
	}
	
	// Update is called once per frame
	void Update ()
    {
       
        if (TimetillNextlevel > 0)
        {
            TimetillNextlevel -= Time.deltaTime;
            if (TimetillNextlevel < 0)
            {
                LoadNextScene();
            }
        }
        
        
	
	}
    public void LoadNextScene()
    {
        int currentindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentindex + 1);
    }
    public void LoadIntro()
    {
        int currentindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);
    }
}
