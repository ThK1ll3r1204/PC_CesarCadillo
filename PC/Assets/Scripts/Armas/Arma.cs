using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public Transform firePoint; // Punto de origen del disparo
    public GameObject bulletPrefab; // Prefab de la bala
    public float bulletForce = 10f; // Fuerza de la bala
    public float fireRate = 0.5f; // Tasa de disparo (balas por segundo)
    protected float nextFireTime = 0f;


    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    public virtual void Shoot()
    {
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
        }
    }
}
