using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ametralladora : Arma
{
    public float timeBetweenShots = 0.3f; 
    private float lastShotTime;

    void Start()
    {
        bulletPrefab = Resources.Load<GameObject>("BalaAmetralladora"); 
    }

    public override void Shoot()
    {
        if (Time.time - lastShotTime >= timeBetweenShots)
        {
            base.Shoot();
            lastShotTime = Time.time;
        }
    }
}
