using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escopeta : Arma
{
    public int pellets = 3;
    void Start()
    {
        bulletPrefab = Resources.Load<GameObject>("BalaEscopeta");
    }
    public override void Update()
    {
        Shoot();
    }

    public override void Shoot()
    {
        base.Shoot();
        for (int i = 0; i < pellets - 1; i++)
        {
            base.Shoot();
        }
    }
}
