using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oxpipebreak : MonoBehaviour
{
    public GameObject pipe;
    public GameObject water = null;
    public float timetodeactivate = 10.0f;

    private void Start()
    {
        timetodeactivate = Random.Range(15, 25);
        //print(timetodeactivate);
    }

    // Update is called once per frame
    void Update()
    {

        if (timetodeactivate > 0)
        {
            timetodeactivate -= Time.deltaTime;
            if (timetodeactivate < 0)
            {
                PipeIsBroken(pipe, water);
            }
        }
    }
    private void PipeIsBroken(GameObject pipe, GameObject water)
    {
        pipe.SetActive(false);
        //water.SetActive(true);


    }
}
