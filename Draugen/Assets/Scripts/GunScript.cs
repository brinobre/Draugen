using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    private AudioSource FireAudio;

    [SerializeField] private GameObject impactEffect;
    [SerializeField] float damage = 10f;
    [SerializeField] float range = 100f;
    [SerializeField] private ParticleSystem ShootLight;
    [SerializeField] Camera fpsCam;
    [SerializeField] private float impactForce = 30;
    [SerializeField] private float fireRate = 15;
    [SerializeField] private float nextTimeToFire = 0f;



    private void Start()
    {
        FireAudio = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();

            FireAudio.Play();

        }

    }


    void Shoot()
    {
        ShootLight.Play();


        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            ShootingTarget target = hit.transform.GetComponent<ShootingTarget>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 2f);
            
        }
    }
}

