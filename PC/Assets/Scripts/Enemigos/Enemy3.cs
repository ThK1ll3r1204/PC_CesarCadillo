using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Enemy
{
    public float speed = 3f;
    private Vector3 currentDirection;
    private float changeDirectionTime = 5f;
    private float lastChangeTime;

    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        if (Time.time - lastChangeTime >= changeDirectionTime)
        {
            lastChangeTime = Time.time;
            currentDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        }

        transform.Translate(currentDirection * speed * Time.deltaTime);
    }
    void Shoot()
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
