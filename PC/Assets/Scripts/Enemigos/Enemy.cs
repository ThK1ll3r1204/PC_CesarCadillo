using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100; 
    public int damage = 10; 
    public float fireRate = 1.0f;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 10f;
    protected float nextFireTime = 0f;

    public virtual void Awake()
    {
        firePoint= GameObject.Find("EnemyFirePoint").GetComponent<Transform>();
        bulletPrefab = Resources.Load<GameObject>("enemyBullet");
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject); 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            //int damage = other.GetComponent<PlayerBullet>().damage; 
            TakeDamage(damage);
            Destroy(other.gameObject); 
        }
        
    }

}
