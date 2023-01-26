using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solakameradöndürücünündöndürücüsü : MonoBehaviour
{
    public float öncekiyaçısı;




    public void soladönmebaşlangıcı()
    {
        InvokeRepeating("soladönme", 0.01f, 0.01f);
        //0,9sn
    }
    public void soladönme()
    {

        gameObject.transform.Rotate(0, 1, 0);
        if (öncekiyaçısı + 90 == 360)
        {
            if (gameObject.transform.eulerAngles.y > 0 && gameObject.transform.eulerAngles.y < 90)
            {
                
                CancelInvoke("soladönme");
               


            }
        }
        if (gameObject.transform.eulerAngles.y >= öncekiyaçısı + 90)
        {


            CancelInvoke("soladönme");


        }
    }
}
