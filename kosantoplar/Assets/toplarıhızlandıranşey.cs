using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toplarıhızlandıranşey : MonoBehaviour
{
    public GameObject kamera;
    public GameObject puansistemi;
    public GameObject merkez;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "top")
        {
            if (other.gameObject.GetComponent<karakter>().enemy == false && other.gameObject.GetComponent<karakter>().canplay == true && other.gameObject.GetComponent<karakter>().levelbitti == false)
            {
                other.gameObject.GetComponent<SphereCollider>().isTrigger = true;
                merkez.GetComponent<merkezsc>().levelbitti = true;
                other.gameObject.GetComponent<karakter>().levelbitti = true;
                puansistemi.GetComponent<puansistemi>().puan++;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        


        if (other.gameObject.tag == "top")
        {
            if (other.gameObject.GetComponent<karakter>().enemy == false && other.gameObject.GetComponent<karakter>().canplay == true)
            {
                merkez.GetComponent<merkezsc>().speed = 30;
                other.gameObject.GetComponent<karakter>().speed = 30;
                kamera.GetComponent<kamera>().levelbitti = true;
                merkez.GetComponent<merkezsc>().levelbitti = true;
                other.gameObject.GetComponent<karakter>().levelbitti = true;
                
            }
        }
    }
   
}
