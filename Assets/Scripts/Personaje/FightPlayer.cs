using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class FightPlayer : MonoBehaviour
{
    [SerializeField] private float health;
    public void TomarDa�o(float da�o)
    {
        health -= da�o;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
