using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class puansistemi : MonoBehaviour
{
    public GameObject puanyaz�s�;
    public int puan;
    public float puankatlama;
    private void FixedUpdate()
    {
        puanyaz�s�.GetComponent<TextMeshProUGUI>().text ="puan�n:" + (puan*puankatlama).ToString("0");
    }
    public void yenidenba�lat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
