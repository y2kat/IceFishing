using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyro : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    float moveSpeed = 5f; // Velocidad de movimiento

    void Start()
    {
        Input.gyro.enabled = true;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //aceleración vertical del giroscopio
        float dirY = Input.gyro.rotationRateUnbiased.y;

        //calcula la velocidad de movimiento vertical
        float verticalVelocity = dirY * moveSpeed;

        //aplica la velocidad al personaje
        rb.velocity = new Vector3(0f, verticalVelocity, 0f);

        // limita la posición y del objeto a los límites de la pantalla
        var pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.y = Mathf.Clamp(pos.y, 0.1f, 0.9f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
