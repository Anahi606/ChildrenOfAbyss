using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOne : MonoBehaviour
{
    private Animator animator;
    public Rigidbody2D rb2D;
    public Transform jugador;
    private bool mirandoDerecha = true;

    [Header("Vida")]
    [SerializeField] private float vida;
    //[SerializeField] private BarraDeVida barraDeVida;

    [Header("Ataque")]
    [SerializeField] private Transform AttackController;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float dañoAtaque;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        //barraDeVida.InicializarBarraDeVida(vida);
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        float distanciaJugador = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("distanciaJugador", distanciaJugador);
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;
        //barraDeVida.CambiarVidaActual(vida);
        if (vida <= 0)
        {
            animator.SetTrigger("Death");
        }
    }
    private void Muerte()
    {
        Destroy(gameObject);
    }
    public void MirarJugador()
    {
        if ((jugador.position.x > transform.position.x && !mirandoDerecha) || (jugador.position.x < transform.position.x && mirandoDerecha))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    public void Ataque()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(AttackController.position, radioAtaque);

        foreach (Collider2D collision in objetos)
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<FightPlayer>().TomarDaño(dañoAtaque);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackController.position, radioAtaque);
    }

}
