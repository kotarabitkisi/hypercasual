using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class merkezsc : MonoBehaviour
{
    public bool çalışıyor;
    public Vector3 kamerakoordinat;
    public float öncekiyaçısı;
    public GameObject kazandın;
    public GameObject kaybettin;
    public GameObject[] bütüntoplar;
    public GameObject[] dosttoplar;
    public float charsayısı=0;
    public bool levelbitti = false;
    private Touch a;
    public Rigidbody karakterrb;
    public float speed = 10;
    public Vector3 merkez;
    public GameObject kamera;
    // Start is called before the first frame update

    private void FixedUpdate()
    {
        if (çalışıyor)
        {
            charsayısı = 0;
            gameObject.transform.Translate(speed * Time.fixedDeltaTime, 0, 0);

            bütüntoplar = GameObject.FindGameObjectsWithTag("top");

            for (int dostsayısı = 0; dostsayısı <= bütüntoplar.Length - 1; dostsayısı++)
            {
                if (bütüntoplar[dostsayısı].GetComponent<karakter>().canplay && bütüntoplar[dostsayısı].GetComponent<karakter>().enemy == false)
                {
                    charsayısı++;

                }



            }
            for (int dostsayısı = 0; dostsayısı <= bütüntoplar.Length - 1; dostsayısı++)
            {
                if (bütüntoplar[dostsayısı].GetComponent<karakter>().canplay && bütüntoplar[dostsayısı].GetComponent<karakter>().enemy == false)
                {


                    bütüntoplar[dostsayısı].transform.localScale = new Vector3(1 / Mathf.Sqrt(Mathf.Sqrt(Mathf.Sqrt(Mathf.Sqrt(charsayısı)))), 1 / Mathf.Sqrt(Mathf.Sqrt(Mathf.Sqrt(Mathf.Sqrt(charsayısı)))), 1 / Mathf.Sqrt(Mathf.Sqrt(Mathf.Sqrt(Mathf.Sqrt(charsayısı)))));
                }



            }


            if (charsayısı == 0)
            {
                if (levelbitti)
                {
                    gameObject.SetActive(false);
                    kazandın.SetActive(true);


                }
                else
                {

                    gameObject.SetActive(false);
                    kaybettin.SetActive(true);
                }

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (çalışıyor)
        {
            if (gameObject.transform.eulerAngles.y > 360) { transform.Rotate(0, -360, 0); }
            if (Input.touchCount > 0)
            {
                a = Input.GetTouch(0);


                if (a.phase == TouchPhase.Moved)
                {

                    if (gameObject.transform.eulerAngles.y == 0)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, kamera.transform.position.z - ((a.position.x - (Screen.width / 2)) / Screen.width * 46 * Screen.width / Screen.height));
                    }
                    if (gameObject.transform.eulerAngles.y == 90)
                    {
                        transform.position = new Vector3(kamera.transform.position.x - ((a.position.x - (Screen.width / 2)) / Screen.width * 46 * Screen.width / Screen.height), transform.position.y, transform.position.z);
                    }
                    if (gameObject.transform.eulerAngles.y == 180)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, kamera.transform.position.z + ((a.position.x - (Screen.width / 2)) / Screen.width * 46 * Screen.width / Screen.height));
                    }
                    if (gameObject.transform.eulerAngles.y == 270)
                    {
                        transform.position = new Vector3(kamera.transform.position.x + ((a.position.x - (Screen.width / 2)) / Screen.width * 46 * Screen.width / Screen.height), transform.position.y, transform.position.z);
                    }


                }

            }
        }
    }
    public void sağadönmebaşlangıcı()
    {
        InvokeRepeating("sağadönme", 0.01f, 0.01f);

    }
    public void sağadönme()
    {

        gameObject.transform.Rotate(0, 1, 0);
        if (öncekiyaçısı + 90 == 360)
        {
            if (gameObject.transform.eulerAngles.y > 0&& gameObject.transform.eulerAngles.y < 90)
            {
                gameObject.transform.SetLocalPositionAndRotation(gameObject.transform.position, Quaternion.Euler(0, 0, 0));
              
                CancelInvoke("sağadönme");
               
            }
        }
        if (gameObject.transform.eulerAngles.y >= öncekiyaçısı + 90)
        {
            CancelInvoke("sağadönme");
          
            gameObject.transform.SetLocalPositionAndRotation(gameObject.transform.position, Quaternion.Euler(0, öncekiyaçısı + 90, 0));
            
        }

    }
    public void soladönmebaşlangıcı()
    {
        InvokeRepeating("soladönme", 0.01f, 0.01f);

    }
    public void soladönme()
    {

        gameObject.transform.Rotate(0, -1, 0);
        if (öncekiyaçısı - 90 == 0) {
            if (gameObject.transform.eulerAngles.y < 360 && gameObject.transform.eulerAngles.y > 270) {
                gameObject.transform.SetLocalPositionAndRotation(gameObject.transform.position, Quaternion.Euler(0, 0, 0));
               
                CancelInvoke("soladönme");
                
            }
        }
        if (gameObject.transform.eulerAngles.y <= öncekiyaçısı - 90)
        {
            gameObject.transform.SetLocalPositionAndRotation(gameObject.transform.position,Quaternion.Euler(0,öncekiyaçısı - 90,0));
           
            CancelInvoke("soladönme");
           
        }

    }
}
