using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class puansistemi : MonoBehaviour
{
    public GameObject puanyazısı;
    public int puan;
    public float puankatlama;
    private void FixedUpdate()
    {
        puanyazısı.GetComponent<TextMeshProUGUI>().text ="puanın:" + (puan*puankatlama).ToString("0");
    }
    public void yenidenbaşlat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
