using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakter : MonoBehaviour
{
    public bool kalýcýhasar;
    public bool çalýþýyor;
    public float öncekiyaçýsý;
    public Vector3 öncekimerkezkoordinat;
    public bool levelbitti = false;
    private Touch a;
    public Rigidbody karakterrb;
    public bool canplay = false;
    public bool enemy = false;
    public float speed =10;
    public Material oyuncu;
    public Material hareketetmeyenoyuncu;
    public Material düþman;
    public GameObject merkez;
    public GameObject kamera;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (canplay && enemy)
            {
                çalýþýyor = true;
            }
        }
        if (çalýþýyor)
        {
            if (canplay && !enemy)
            {
                if (!levelbitti)
                {
                    if (Input.touchCount > 0)
                    {
                        a = Input.GetTouch(0);
                        if (a.phase == TouchPhase.Moved)
                        {
                           

                        }

                    }
                }
            }
            öncekimerkezkoordinat = merkez.transform.position;
        }
    }
    void FixedUpdate()
    {
        
            if (gameObject.transform.eulerAngles.y >= 360) { transform.Rotate(0, -360, 0); }


        if (canplay && enemy)
        {
            gameObject.GetComponent<Light>().enabled = true;
            this.gameObject.GetComponent<MeshRenderer>().material = düþman;
            gameObject.GetComponent<Light>().color = Color.red;
            if (çalýþýyor)
            { karakterrb.velocity = new Vector3(-speed, karakterrb.velocity.y, karakterrb.velocity.z);
            
            }
        }
            if (!canplay) {
            
            this.gameObject.GetComponent<MeshRenderer>().material = hareketetmeyenoyuncu;
            gameObject.GetComponent<Light>().enabled = false;
        }






            if (canplay && !enemy)
            {
            gameObject.GetComponent<Light>().enabled = true;
            gameObject.GetComponent<Light>().color = Color.green;
            if (levelbitti)
                {
                    
                    gameObject.GetComponent<SphereCollider>().isTrigger = true;
                    gameObject.GetComponent<Rigidbody>().useGravity = false;
                    

                }
                
                if (çalýþýyor)
                {
                    gameObject.transform.Translate(speed * Time.fixedDeltaTime, 0, 0);
                }
                gameObject.transform.SetLocalPositionAndRotation(new Vector3(gameObject.transform.position.x,10.5f,gameObject.transform.position.z),gameObject.transform.rotation);
                    karakterrb.velocity = new Vector3(
                    10 * (merkez.transform.position.x - gameObject.transform.position.x),
                    0 * (merkez.transform.position.y - 5 - gameObject.transform.position.y),
                    10 * (merkez.transform.position.z - gameObject.transform.position.z)
                    );
                

                this.gameObject.GetComponent<MeshRenderer>().material = oyuncu;
            }



        
    }
    private void OnCollisionStay(Collision collision)
    {
        
            if (collision.gameObject.tag == "top")
            {
                if (canplay && enemy) { if (collision.gameObject.GetComponent<karakter>().enemy == false) { Destroy(this.gameObject); } }
                if (canplay && !enemy)
                {
                    if (collision.gameObject.GetComponent<karakter>().enemy == true) { Destroy(this.gameObject); }
                }
            if (!canplay)
            {
                if (kalýcýhasar == false)
                {
                    if (collision.gameObject.GetComponent<karakter>().enemy == false)
                    {
                        this.gameObject.GetComponent<karakter>().enemy = false;
                        this.gameObject.GetComponent<karakter>().canplay = true;
                        this.gameObject.GetComponent<karakter>().çalýþýyor = true;
                    }
                    if (collision.gameObject.GetComponent<karakter>().enemy == true)
                    {
                        this.gameObject.GetComponent<karakter>().enemy = true;
                        this.gameObject.GetComponent<karakter>().canplay = true;
                        this.gameObject.GetComponent<karakter>().çalýþýyor = true;
                    }
                }
            }

            }
            if (collision.gameObject.tag == "yokedici") { Destroy(this.gameObject); }
            
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "köreltici") { if (gameObject.GetComponent<karakter>().enemy == false) { gameObject.GetComponent<karakter>().canplay = false; kalýcýhasar = true; } }
    }
    public void saðadönmebaþlangýcý()
    {
        InvokeRepeating("saðadönme", 0.01f, 0.01f);

    }
    public void saðadönme()
    {

        gameObject.transform.Rotate(0, 1, 0);
        if (öncekiyaçýsý - 90 == 0)
        {
            if (gameObject.transform.eulerAngles.y < 360&& gameObject.transform.eulerAngles.y>270)
            {
                gameObject.transform.SetLocalPositionAndRotation(gameObject.transform.position, Quaternion.Euler(0, 0, 0));
                CancelInvoke("saðadönme");
            }
        }
        if (gameObject.transform.eulerAngles.y >= öncekiyaçýsý + 90)
        {
            CancelInvoke("saðadönme");
            gameObject.transform.SetLocalPositionAndRotation(gameObject.transform.position, Quaternion.Euler(0, öncekiyaçýsý + 90, 0));
        }

    }
    public void soladönmebaþlangýcý()
    {
        InvokeRepeating("soladönme", 0.01f, 0.01f);

    }
    public void soladönme()
    {

        gameObject.transform.Rotate(0, -1, 0);
        if (öncekiyaçýsý - 90 == 0)
        {
            if (gameObject.transform.eulerAngles.y < 360&&gameObject.transform.eulerAngles.y < 90)
            {
                gameObject.transform.SetLocalPositionAndRotation(gameObject.transform.position, Quaternion.Euler(0, 0, 0));               
                CancelInvoke("soladönme");
            }
        }
        if (gameObject.transform.eulerAngles.y <= öncekiyaçýsý - 90)
        {
            gameObject.transform.SetLocalPositionAndRotation(gameObject.transform.position, Quaternion.Euler(0, öncekiyaçýsý - 90, 0));
            CancelInvoke("soladönme");
        }

    }
}
