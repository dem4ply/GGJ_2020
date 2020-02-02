using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luzparpadeante : MonoBehaviour
{


    Light testLight;
    public float minWaitTime;
    public float maxWaitTime;

   public bool enable_light = true;

    void Start()
    {
        testLight = GetComponent<Light>();
        StartCoroutine(Flashing());
    }

   public void shutdown()
   {
      enable_light = false;
      testLight.enabled = false;
   }

    IEnumerator Flashing()
    {
        while ( enable_light )
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            if ( enable_light )
               testLight.enabled = !testLight.enabled;

        }
    }
}

