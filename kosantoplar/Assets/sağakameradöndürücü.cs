using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sağakameradöndürücü : MonoBehaviour
{
    public Vector3 kamerakoordinat;
    public float öncekiyaçısı;
    public Vector3 merkezkoor;
    public GameObject kamera;
    public GameObject merkez;
    private void Start()
    {
        kamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    public void sağadönmebaşlangıcı()
    {
        InvokeRepeating("sağadönme", 0.01f, 0.01f);
        //0,9sn
    }
    public void sağadönme()
    {
       
        gameObject.transform.Rotate(0, 2f, 0);
        if (öncekiyaçısı + 90 == 360)
        {
            if (merkez.transform.eulerAngles.y > 0 && merkez.transform.eulerAngles.y < 90)
            {
               
                kamera.GetComponent<kamera>().dönüyor = false;
                CancelInvoke("sağadönme");
                kamera.transform.SetParent(null);
                if (merkez.transform.localEulerAngles.y == 0) { kamera.transform.SetLocalPositionAndRotation(new Vector3(gameObject.transform.position.x - 40, merkez.transform.position.y + 15, kamera.transform.position.z), Quaternion.Euler(merkez.transform.rotation.x, 90, merkez.transform.rotation.z)); }
                if (merkez.transform.localEulerAngles.y == 90) { kamera.transform.SetLocalPositionAndRotation(new Vector3(kamera.transform.position.x, merkez.transform.position.y + 15, gameObject.transform.position.z + 40), Quaternion.Euler(merkez.transform.rotation.x, 180, merkez.transform.rotation.z)); }
                if (merkez.transform.localEulerAngles.y == 180) { kamera.transform.SetLocalPositionAndRotation(new Vector3(gameObject.transform.position.x + 40, merkez.transform.position.y + 15, kamera.transform.position.z), Quaternion.Euler(merkez.transform.rotation.x, 270, merkez.transform.rotation.z)); }
                if (merkez.transform.localEulerAngles.y == 270) { kamera.transform.SetLocalPositionAndRotation(new Vector3(kamera.transform.position.x, merkez.transform.position.y + 15, gameObject.transform.position.z - 40), Quaternion.Euler(merkez.transform.rotation.x, 0, merkez.transform.rotation.z)); }




            }
        }
        if (merkez.transform.eulerAngles.y >= öncekiyaçısı +90)
        {
            CancelInvoke("sağadönme");
            
            kamera.transform.SetParent(null);
            kamera.GetComponent<kamera>().dönüyor = false;
            if (merkez.transform.localEulerAngles.y == 0) { kamera.transform.SetLocalPositionAndRotation(new Vector3(gameObject.transform.position.x - 40, merkez.transform.position.y + 15, kamera.transform.position.z), Quaternion.Euler(merkez.transform.rotation.x, 90, merkez.transform.rotation.z)); }
            if (merkez.transform.localEulerAngles.y == 90) { kamera.transform.SetLocalPositionAndRotation(new Vector3(kamera.transform.position.x, merkez.transform.position.y + 15, gameObject.transform.position.z + 40), Quaternion.Euler(merkez.transform.rotation.x, 180, merkez.transform.rotation.z)); }
            if (merkez.transform.localEulerAngles.y == 180) { kamera.transform.SetLocalPositionAndRotation(new Vector3(gameObject.transform.position.x + 40, merkez.transform.position.y + 15, kamera.transform.position.z), Quaternion.Euler(merkez.transform.rotation.x, 270, merkez.transform.rotation.z)); }
            if (merkez.transform.localEulerAngles.y == 270) { kamera.transform.SetLocalPositionAndRotation(new Vector3(kamera.transform.position.x, merkez.transform.position.y + 15, gameObject.transform.position.z - 40), Quaternion.Euler(merkez.transform.rotation.x, 0, merkez.transform.rotation.z)); }



        }


    }

}
