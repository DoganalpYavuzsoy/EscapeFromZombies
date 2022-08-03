using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public int damage;
    public float timeBetweenShootinh, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;
    public AudioSource audioData;
    public AudioClip dataShoot;

    bool shooting, readyToShoot, reloading;


    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    public GameObject impactEffect;
    public ParticleSystem muzzleFlash;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }
    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();
    }

    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        if(readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }

    private void Shoot()
    {
        muzzleFlash.Play();
        audioData.clip = dataShoot;
        audioData.Play();
        readyToShoot = false;
        Debug.Log("Shoting");
        float x = UnityEngine.Random.Range(-spread, spread);
        float y = UnityEngine.Random.Range(-spread, spread);

        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        if(Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);

            if (rayHit.collider.CompareTag("Enemy") || rayHit.collider.CompareTag("Health"))
            {
                Instantiate(impactEffect, rayHit.point, Quaternion.LookRotation(rayHit.normal));
                //rayHit.collider.GetComponent<Shoot>
                /*RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);d
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null)
                    {
                        hit.collider.enabled = false;
                    }
                }*/
                try
                { 
                    rayHit.collider.GetComponent<EnemyController>().takeDamage(damage);

                }catch(Exception ex)
                {

                }

            }
        }

        bulletsLeft--;
        bulletsShot--;
        Invoke("ResetShoot", timeBetweenShootinh);

        if(bulletsShot > 0 && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }
    }

    public void ResetShoot()
    {
        readyToShoot = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }


}
