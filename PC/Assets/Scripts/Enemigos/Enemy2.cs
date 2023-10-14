using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    public float speed = 3f;
    public float changeDirectionTime = 3f;
    private float timeToChangeDirection;
    private Vector3 targetDirection;

    void Update()
    {        
        Move();
        Shoot();
    }

    void Move()
    {
        if (Time.time >= timeToChangeDirection)
        {
            timeToChangeDirection = Time.time + changeDirectionTime;
            targetDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        }

        transform.Translate(targetDirection * speed * Time.deltaTime);
    }

    void Shoot()
    {
        // Implementa el disparo específico para Enemy2
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;

            // Configura la bala y aplica fuerza
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
        }
    }
}
