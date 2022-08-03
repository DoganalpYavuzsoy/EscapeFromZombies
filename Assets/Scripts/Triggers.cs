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
        Trigger.text = "Silah�n� Al ve �lerle.";
    }

   void OnTriggerEnter(Collider collider)
    {
        if (this.gameObject.tag == "Trigger1")
        {
            Trigger.text = "D��manlar� �ld�r ve Labirent'ten ��k��� Bul.";
        }
        
        if (this.gameObject.tag == "Trigger2")
        {
            Trigger.text = "Tebrikler B�l�m� Ba�ar�yla Tamamlad�n!";
        }
      
        if (this.gameObject.tag == "Trigger3")
        {
            Trigger.text = "Yeni Silah�n� Al ve �lerle.";
        }
        if (this.gameObject.tag == "Trigger4")
        {
            Trigger.text = "B�l�m� Tamamlamak ��in Tekne'ye Bin.";
        }
        if (this.gameObject.tag == "Trigger5")
        {
            Trigger.text = "B�l�m� Tamamlamak ��in D��manlar� �ld�r Ve Tekne'yi Bul.";
        }
        if (this.gameObject.tag == "Trigger6")
        {
            Trigger.text = "Tebrikler B�l�m� Ba�ar�yla Tamamlad�n!";
            FinishPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }


    }
}
