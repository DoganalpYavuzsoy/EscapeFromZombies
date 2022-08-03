using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Triggers : MonoBehaviour
{
    public Text Trigger;
    public GameObject FinishPanel;

    void Start()
    {
        Trigger.text = "Silahýný Al ve Ýlerle.";
    }

   void OnTriggerEnter(Collider collider)
    {
        if (this.gameObject.tag == "Trigger1")
        {
            Trigger.text = "Düþmanlarý Öldür ve Labirent'ten Çýkýþý Bul.";
        }
        
        if (this.gameObject.tag == "Trigger2")
        {
            Trigger.text = "Tebrikler Bölümü Baþarýyla Tamamladýn!";
        }
      
        if (this.gameObject.tag == "Trigger3")
        {
            Trigger.text = "Yeni Silahýný Al ve Ýlerle.";
        }
        if (this.gameObject.tag == "Trigger4")
        {
            Trigger.text = "Bölümü Tamamlamak Ýçin Tekne'ye Bin.";
        }
        if (this.gameObject.tag == "Trigger5")
        {
            Trigger.text = "Bölümü Tamamlamak Ýçin Düþmanlarý Öldür Ve Tekne'yi Bul.";
        }
        if (this.gameObject.tag == "Trigger6")
        {
            Trigger.text = "Tebrikler Bölümü Baþarýyla Tamamladýn!";
            FinishPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }


    }
}
