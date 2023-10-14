using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : Arma
{
    void Start()
    {
        bulletPrefab = Resources.Load<GameObject>("BalaPistola"); 
    }

    public override void Update()
    {
        Shoot();
    }

    public override void Shoot()
    {
        base.Shoot();
    }
}
