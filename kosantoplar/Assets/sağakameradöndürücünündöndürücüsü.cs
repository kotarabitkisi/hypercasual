using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sağakameradöndürücünündöndürücüsü : MonoBehaviour
{

    public float öncekiyaçısı;
    
  


    public void sağadönmebaşlangıcı()
    {
        InvokeRepeating("sağadönme", 0.01f, 0.01f);
        //0,9sn
    }
    public void sağadönme()
    {
        gameObject.transform.Rotate(0, -1, 0);
        if (gameObject.transform.eulerAngles.y - 90 <= 0)
        {
            if (gameObject.transform.eulerAngles.y > 270 && gameObject.transform.eulerAngles.y < 360)
            {
                CancelInvoke("sağadönme");





            }
        }
        if (gameObject.transform.eulerAngles.y <= öncekiyaçısı-90)
        {
            

            CancelInvoke("sağadönme");


        }
    }
}
