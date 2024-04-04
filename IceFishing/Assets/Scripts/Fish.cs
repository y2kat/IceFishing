using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public float speed = 2f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(-speed, 0);

        if (transform.position.x < -10)
        {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FishingRod"))
        {
            // Suma puntos a la caña de pescar
            collision.gameObject.GetComponent<FishingRod>().AddPoints();
            Debug.Log("me tocó el pez");
            // Desactiva el pez para que pueda ser reutilizado
            gameObject.SetActive(false);
        }
    }
}
