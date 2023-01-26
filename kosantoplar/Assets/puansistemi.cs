using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class puansistemi : MonoBehaviour
{
    public GameObject puanyazýsý;
    public int puan;
    public float puankatlama;
    private void FixedUpdate()
    {
        puanyazýsý.GetComponent<TextMeshProUGUI>().text ="puanýn:" + (puan*puankatlama).ToString("0");
    }
    public void yenidenbaþlat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
