using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    [SerializeField] Rigidbody2D rb;
    public bool moveRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //mueve el enemigo en la dirección especificada
        float direction = moveRight ? 1 : -1;
        rb.velocity = new Vector2(speed * direction, 0);

        if (transform.position.x > 10)
        {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si el enemigo colisiona con la caña de pescar
        if (collision.gameObject.CompareTag("FishingRod"))
        {
            // Resta una vida a la caña de pescar
            collision.gameObject.GetComponent<FishingRod>().LoseLife();
            // Desactiva el enemigo para que pueda ser reutilizado
            gameObject.SetActive(false);
        }
    }
}
