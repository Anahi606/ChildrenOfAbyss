using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float daño = 10f;
    private IDamagable iDamageable;

    public Collider2D EnemyColl { get; set; }
    private Collider2D coll;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
        IgnoreCollisionWithEnemyToggle();

        Destroy(gameObject, 2.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        iDamageable = collision.gameObject.GetComponent<IDamagable>();

        if (iDamageable != null)
        {
            iDamageable.TomarDaño(daño);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

    private void IgnoreCollisionWithEnemyToggle()
    {
        if (!Physics2D.GetIgnoreCollision(coll, EnemyColl))
        {
            Physics2D.IgnoreCollision(coll, EnemyColl, true);
        }
        else
        {
            Physics2D.IgnoreCollision(coll, EnemyColl, false);
        }
    }
}
