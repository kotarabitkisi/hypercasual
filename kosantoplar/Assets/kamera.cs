using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{
    public float levelbittix=40;
    public float levelbittiy=15;
    public bool levelbitti;
    public GameObject merkez;
    public GameObject[] bütüntoplar;
    public GameObject[] dostkarakterler;
    public float koordinatortx;
    public float koordinatortz;
    public float koordinattopx;
    public float koordinattopz;
    public float charsayýsý;
    public bool dönüyor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.transform.eulerAngles.y >= 360) { transform.Rotate(0, -360, 0); }
        if (gameObject.transform.eulerAngles.y < 0) { transform.Rotate(0, 360, 0); }
        koordinattopx = 0;
        koordinattopz = 0;
        koordinatortx = 0;
        koordinatortz = 0;
        charsayýsý = 0;
        bütüntoplar = GameObject.FindGameObjectsWithTag("top");
        
        for(int dostsayýsý=0; dostsayýsý<=bütüntoplar.Length-1; dostsayýsý++)
        {
            if(bütüntoplar[dostsayýsý].GetComponent<karakter>().canplay && bütüntoplar[dostsayýsý].GetComponent<karakter>().enemy==false) {
                koordinattopx += bütüntoplar[dostsayýsý].GetComponent<Transform>().position.x;
                koordinattopz += bütüntoplar[dostsayýsý].GetComponent<Transform>().position.z;
                charsayýsý++;
            }

        }




        if (charsayýsý != 0 && !dönüyor) { 
            koordinatortx = koordinattopx /charsayýsý;
                koordinatortz = koordinattopz / charsayýsý;
            if (!levelbitti) { 
               
           
            if (merkez.transform.localEulerAngles.y==0) {gameObject.transform.SetLocalPositionAndRotation(new Vector3(merkez.transform.position.x - 40, merkez.transform.position.y +15,gameObject.transform.position.z),Quaternion.Euler(merkez.transform.rotation.x, 90, merkez.transform.rotation.z) );}
            if (merkez.transform.localEulerAngles.y == 90) { gameObject.transform.SetLocalPositionAndRotation(new Vector3(gameObject.transform.position.x , merkez.transform.position.y + 15, merkez.transform.position.z+40), Quaternion.Euler(merkez.transform.rotation.x, 180, merkez.transform.rotation.z)); }
            if (merkez.transform.localEulerAngles.y == 180) { gameObject.transform.SetLocalPositionAndRotation(new Vector3(merkez.transform.position.x + 40, merkez.transform.position.y + 15, gameObject.transform.position.z), Quaternion.Euler(merkez.transform.rotation.x, 270, merkez.transform.rotation.z)); }
            if (merkez.transform.localEulerAngles.y == 270) { gameObject.transform.SetLocalPositionAndRotation(new Vector3(gameObject.transform.position.x, merkez.transform.position.y + 15, merkez.transform.position.z - 40), Quaternion.Euler(merkez.transform.rotation.x, 0, merkez.transform.rotation.z)); }
 }
            else
            {
                if (levelbittix < 80)
                {
                    levelbittix += 40 * Time.fixedDeltaTime;
                }
                else { levelbittix = 80; }
                if (levelbittiy < 30) 
                {
                    levelbittiy += 15*Time.fixedDeltaTime; 
                }
                else { levelbittiy = 30; }
                
                gameObject.transform.SetLocalPositionAndRotation(new Vector3(merkez.transform.position.x - levelbittix, 10.5f + levelbittiy, gameObject.transform.position.z), Quaternion.Euler(merkez.transform.rotation.x, 90, merkez.transform.rotation.z));


            }
       


        }
        
        
    }
}

