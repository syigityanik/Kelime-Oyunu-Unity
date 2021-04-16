using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class göster : MonoBehaviour
{
    public Text adtext;
    public Text ad;
    public Text puan;
    public Text tarih;
    public Text saat;
    public Text süre;

    Oyun y = new Oyun();
    Timer t = new Timer();
    void Start()
    {
    
    }


    void Update()
    {
        
    }
     public void gösterelim()

    {
        DateTime theTime = DateTime.Now;
        string date = theTime.ToString("yyyy-MM-dd");
        string time = theTime.ToString("HH:mm:ss");
        ad.GetComponent<Text>().text = adtext.GetComponent<Text>().text;
        puan.GetComponent<Text>().text = y.puan.ToString();
        tarih.GetComponent<Text>().text = date;
        saat.GetComponent<Text>().text = time;
        süre.GetComponent<Text>().text = t.minutes.ToString() + ":" + t.seconds.ToString();

    }




}
