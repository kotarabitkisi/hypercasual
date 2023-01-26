using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dönenşey : MonoBehaviour
{

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.Rotate(0,45*Time.fixedDeltaTime,0);
    }
   
}
