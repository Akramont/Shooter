using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text time;
    public static float timingOfLastRespawn =0;    
       

    // Start is called before the first frame update
   
   
    // Update is called once per frame
    void Update()
    {
        time.text = (int)(Time.time - timingOfLastRespawn) + "." + (int)(10*((Time.time - timingOfLastRespawn)%1)) + ""; //костылище, но все рабит)

    }
}
