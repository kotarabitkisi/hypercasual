using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solakameradöndürücü : MonoBehaviour
{
    public Vector3 kamerakoordinat;
    public float öncekiyaçısı;
    public Vector3 merkezkoor;
    public GameObject merkez;
    public GameObject kamera;
    private void Start()
    {
        kamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    public void soladönmebaşlangıcı()
    {
        InvokeRepeating("soladönme", 0.01f, 0.01f);

    }
    public void soladönme()
    {
        Debug.Log(gameObject.transform.eulerAngles.y);
        gameObject.transform.Rotate(0, -2, 0);
        if (öncekiyaçısı - 90 <= 0)
        {
            Debug.Log("bu kısım çalışıyor");
            if (gameObject.transform.eulerAngles.y>180 && gameObject.transform.eulerAngles.y < 270)
            {
                Debug.Log("çalışıyor");
                CancelInvoke("soladönme");

                kamera.transform.SetParent(null);
                kamera.GetComponent<kamera>().dönüyor = false;
                if (merkez.transform.localEulerAngles.y == 0) { kamera.transform.SetLocalPositionAndRotation(new Vector3(gameObject.transform.position.x - 40, merkez.transform.position.y + 15, kamera.transform.position.z), Quaternion.Euler(merkez.transform.rotation.x, 90, merkez.transform.rotation.z)); }
                if (merkez.transform.localEulerAngles.y == 90) { kamera.transform.SetLocalPositionAndRotation(new Vector3(kamera.transform.position.x, merkez.transform.position.y + 15, gameObject.transform.position.z + 40), Quaternion.Euler(merkez.transform.rotation.x, 180, merkez.transform.rotation.z)); }
                if (merkez.transform.localEulerAngles.y == 180) { kamera.transform.SetLocalPositionAndRotation(new Vector3(gameObject.transform.position.x + 40, merkez.transform.position.y + 15, kamera.transform.position.z), Quaternion.Euler(merkez.transform.rotation.x, 270, merkez.transform.rotation.z)); }
                if (merkez.transform.localEulerAngles.y == 270) { kamera.transform.SetLocalPositionAndRotation(new Vector3(kamera.transform.position.x, merkez.transform.position.y + 15, gameObject.transform.position.z - 40), Quaternion.Euler(merkez.transform.rotation.x, 0, merkez.transform.rotation.z)); }




            }



        }
        if (gameObject.transform.eulerAngles.y <= öncekiyaçısı-90)
        {
          
            CancelInvoke("soladönme");

            kamera.transform.SetParent(null);
            kamera.GetComponent<kamera>().dönüyor = false;
            if (merkez.transform.localEulerAngles.y == 0) { kamera.transform.SetLocalPositionAndRotation(new Vector3(gameObject.transform.position.x - 40, merkez.transform.position.y + 15, kamera.transform.position.z), Quaternion.Euler(merkez.transform.rotation.x, 90, merkez.transform.rotation.z)); }
            if (merkez.transform.localEulerAngles.y == 90) { kamera.transform.SetLocalPositionAndRotation(new Vector3(kamera.transform.position.x, merkez.transform.position.y + 15, gameObject.transform.position.z + 40), Quaternion.Euler(merkez.transform.rotation.x, 180, merkez.transform.rotation.z)); }
            if (merkez.transform.localEulerAngles.y == 180) { kamera.transform.SetLocalPositionAndRotation(new Vector3(gameObject.transform.position.x + 40, merkez.transform.position.y + 15, kamera.transform.position.z), Quaternion.Euler(merkez.transform.rotation.x, 270, merkez.transform.rotation.z)); }
            if (merkez.transform.localEulerAngles.y == 270) { kamera.transform.SetLocalPositionAndRotation(new Vector3(kamera.transform.position.x, merkez.transform.position.y + 15, gameObject.transform.position.z - 40), Quaternion.Euler(merkez.transform.rotation.x, 0, merkez.transform.rotation.z)); }



        }

    }
}
