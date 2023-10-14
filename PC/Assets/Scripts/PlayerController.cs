using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform firePoint; 
    public float bulletForce = 10f; 

    private bool isShooting = false;
    private float fireRate = 0.3f;
    private float nextFire = 0f;

    public int playerHealth = 100;
    public float moveSpeed = 5f; 
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer(); 

    }
    
    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        movement.Normalize();

        rb.AddForce(movement * moveSpeed);
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;

        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            int damage = other.GetComponent<Enemy>().damage; 
            TakeDamage(damage);
        }

        if (other.CompareTag("EnemyBullet"))
        {
            int damage = other.GetComponent<Enemy>().damage; 
            TakeDamage(damage);
            Destroy(other.gameObject);
        }
    }

}

