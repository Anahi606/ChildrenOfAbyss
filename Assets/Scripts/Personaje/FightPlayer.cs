using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class FightPlayer : MonoBehaviour
{
    [SerializeField] private float health;
    public void TomarDaño(float daño)
    {
        health -= daño;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
