using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class başlamaekranı : MonoBehaviour
{
    public GameObject merkez;
    public GameObject karakter;
    public GameObject ilktop;
    
    private void FixedUpdate()
    {
        
        if (Input.touchCount > 0)
        {
            ilktop.GetComponent<karakter>().canplay = true;
            merkez.GetComponent<merkezsc>().çalışıyor = true;
            karakter.GetComponent<karakter>().çalışıyor = true;
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
    }
}
