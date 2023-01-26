using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leveltamamlamaşeys : MonoBehaviour
{
    public Material material;
    public int gerekentop = 5;
    public GameObject puansistemi;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "top") { 
            if (other.gameObject.GetComponent<karakter>().enemy == false && other.gameObject.GetComponent<karakter>().canplay == true && other.gameObject.GetComponent<karakter>().levelbitti == true && gerekentop>0) 
            {
                puansistemi.GetComponent<puansistemi>().puankatlama += 0.2f;
                gerekentop--;
                other.gameObject.GetComponent<karakter>().canplay = false;
                material = gameObject.GetComponent<MeshRenderer>().material;
                material.EnableKeyword("_EMISSION");
            }
        }
    }
    
}
