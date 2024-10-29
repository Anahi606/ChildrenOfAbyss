using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class FightPlayer : MonoBehaviour, IDamagable
{
    [SerializeField] private float health;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void TomarDa�o(float da�o)
    {
        health -= da�o;

        if (health <= 0)
        {
            Muerte();
        }

    }
    private void Muerte()
    {
        animator.SetTrigger("Death");
    }

}
