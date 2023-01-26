using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class topsayısı : MonoBehaviour
{
    public GameObject merkez;
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = (merkez.GetComponent<merkezsc>().charsayısı).ToString();
    }
}
