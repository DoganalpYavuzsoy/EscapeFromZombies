using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtSystem : MonoBehaviour
{

    [SerializeField] public float health;
    [SerializeField] public Image healthBar;
    [SerializeField] public GameObject healthBarForeGround;

    GameObject Player;

    PlayerMovement playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = Player.GetComponent<PlayerMovement>();
        health = 100;
        if (!healthBarForeGround.activeSelf) healthBarForeGround.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //TODO AŞAĞIDAKİ KOD PARÇASI TEST İÇİN YAPILDI DÜZENLE!
        health -= 1;
        healthBar.fillAmount = health / 100;
        //playerScript.Die();
    }
}
