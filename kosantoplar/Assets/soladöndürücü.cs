using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soladöndürücü : MonoBehaviour
{
    public GameObject döndürücüdöndürücü;
    public GameObject merkez;
    public GameObject kamera;
    public GameObject kameradöndürücü;
    float i = 0;
    float a = 0;
    private void OnCollisionEnter(Collision collision)
    {
        a = collision.gameObject.transform.eulerAngles.y;
        i = collision.gameObject.transform.eulerAngles.y;

        if (collision.gameObject == merkez) {
            kameradöndürücü.GetComponent<solakameradöndürücü>().kamerakoordinat = gameObject.transform.position;
            kameradöndürücü.GetComponent<solakameradöndürücü>().öncekiyaçısı = kameradöndürücü.transform.eulerAngles.y;
            döndürücüdöndürücü.GetComponent<solakameradöndürücünündöndürücüsü>().öncekiyaçısı = döndürücüdöndürücü.transform.eulerAngles.y;
            döndürücüdöndürücü.GetComponent<solakameradöndürücünündöndürücüsü>().soladönmebaşlangıcı();
            kamera.transform.SetParent(kameradöndürücü.transform);
            kamera.GetComponent<kamera>().dönüyor = true;
            merkez.GetComponent<merkezsc>().öncekiyaçısı = merkez.gameObject.transform.eulerAngles.y;
            merkez.GetComponent<merkezsc>().soladönmebaşlangıcı();
            kameradöndürücü.GetComponent<solakameradöndürücü>().soladönmebaşlangıcı();



        }
        else
        {
            collision.gameObject.GetComponent<karakter>().öncekiyaçısı = collision.gameObject.transform.eulerAngles.y;
            collision.gameObject.GetComponent<karakter>().soladönmebaşlangıcı();
        }
    }
}
