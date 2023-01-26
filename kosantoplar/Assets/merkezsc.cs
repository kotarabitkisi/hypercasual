using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class merkezsc : MonoBehaviour
{
    public bool �al���yor;
    public Vector3 kamerakoordinat;
    public float �ncekiya��s�;
    public GameObject kazand�n;
    public GameObject kaybettin;
    public GameObject[] b�t�ntoplar;
    public GameObject[] dosttoplar;
    public float charsay�s�=0;
    public bool levelbitti = false;
    private Touch a;
    public Rigidbody karakterrb;
    public float speed = 10;
    public Vector3 merkez;
    public GameObject kamera;
    // Start is called before the first frame update

    private void FixedUpdate()
    {
        if (�al���yor)
        {
            charsay�s� = 0;
            gameObject.transform.Translate(speed * Time.fixedDeltaTime, 0, 0);

            b�t�ntoplar = GameObject.FindGameObjectsWithTag("top");

            for (int dostsay�s� = 0; dostsay�s� <= b�t�ntoplar.Length - 1; dostsay�s�++)
            {
                if (b�t�ntoplar[dostsay�s�].GetComponent<karakter>().canplay && b�t�ntoplar[dostsay�s�].GetComponent<karakter>().enemy == false)
                {
                    charsay�s�++;

                }



            }
            for (int dostsay�s� = 0; dostsay�s� <= b�t�ntoplar.Length - 1; dostsay�s�++)
            {
                if (b�t�ntoplar[dostsay�s�].GetComponent<karakter>().canplay && b�t�ntoplar[dostsay�s�].GetComponent<karakter>().enemy == false)
                {


                    b�t�ntoplar[dostsay�s�].transform.localScale = new Vector3(1 / Mathf.Sqrt(Mathf.Sqrt(Mathf.Sqrt(Mathf.Sqrt(charsay�s�)))), 1 / Mathf.Sqrt(Mathf.Sqrt(Mathf.Sqrt(Mathf.Sqrt(charsay�s�)))), 1 / Mathf.Sqrt(Mathf.Sqrt(Mathf.Sqrt(Mathf.Sqrt(charsay�s�)))));
                }



            }


            if (charsay�s� == 0)
            {
                if (levelbitti)
                {
                    gameObject.SetActive(false);
                    kazand�n.SetActive(true);


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
        if (�al���yor)
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
    public void sa�ad�nmeba�lang�c�()
    {
        InvokeRepeating("sa�ad�nme", 0.01f, 0.01f);

    }
    public void sa�ad�nme()
    {

        gameObject.transform.Rotate(0, 1, 0);
        if (�ncekiya��s� + 90 == 360)
        {
            if (gameObject.transform.eulerAngles.y > 0&& gameObject.transform.eulerAngles.y < 90)
            {
                gameObject.transform.SetLocalPositionAndRotation(gameObject.transform.position, Quaternion.Euler(0, 0, 0));
              
                CancelInvoke("sa�ad�nme");
               
            }
        }
        if (gameObject.transform.eulerAngles.y >= �ncekiya��s� + 90)
        {
            CancelInvoke("sa�ad�nme");
          
            gameObject.transform.SetLocalPositionAndRotation(gameObject.transform.position, Quaternion.Euler(0, �ncekiya��s� + 90, 0));
            
        }

    }
    public void solad�nmeba�lang�c�()
    {
        InvokeRepeating("solad�nme", 0.01f, 0.01f);

    }
    public void solad�nme()
    {

        gameObject.transform.Rotate(0, -1, 0);
        if (�ncekiya��s� - 90 == 0) {
            if (gameObject.transform.eulerAngles.y < 360 && gameObject.transform.eulerAngles.y > 270) {
                gameObject.transform.SetLocalPositionAndRotation(gameObject.transform.position, Quaternion.Euler(0, 0, 0));
               
                CancelInvoke("solad�nme");
                
            }
        }
        if (gameObject.transform.eulerAngles.y <= �ncekiya��s� - 90)
        {
            gameObject.transform.SetLocalPositionAndRotation(gameObject.transform.position,Quaternion.Euler(0,�ncekiya��s� - 90,0));
           
            CancelInvoke("solad�nme");
           
        }

    }
}
