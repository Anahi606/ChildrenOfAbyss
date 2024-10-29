using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Rigidbody2D bulletPrefab;
    [SerializeField] private float bulletSpeed = 10f;

    private Collider2D coll;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    public void Shoot()
    {
        Rigidbody2D bulletRB = Instantiate(bulletPrefab, transform.position, transform.rotation);

        Vector2 shootDirection = GetShootDirection();
        bulletRB.velocity = shootDirection * bulletSpeed;

        EnemyProjectile enemyProjectile = bulletRB.gameObject.GetComponent<EnemyProjectile>();
        enemyProjectile.EnemyColl = coll;
    }

    public Vector2 GetShootDirection()
    {
        Transform playertrans = GameObject.FindGameObjectWithTag("Player").transform;
        return (playertrans.position - transform.position).normalized;
    }
}
