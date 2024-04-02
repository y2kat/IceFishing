using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FishingRodController : MonoBehaviour
{
    private InputAction tiltAction;
    private LineRenderer lineRenderer;
    public float maxLength = 10f;

    void Awake()
    {
        // Carga el mapa de acciones 'Standard' y la acción 'Tilt'
        tiltAction = new InputActionMap("Standard").FindAction("Tilt");
    }

    void OnEnable()
    {
        // Habilita la acción de inclinación y suscribe el método correspondiente
        tiltAction.Enable();
        tiltAction.performed += OnTiltPerformed;
    }

    void OnDisable()
    {
        // Deshabilita la acción de inclinación y desuscribe el método
        tiltAction.Disable();
        tiltAction.performed -= OnTiltPerformed;
    }

    private void OnTiltPerformed(InputAction.CallbackContext context)
    {
        // Obtiene la actitud del giroscopio y la convierte en una rotación de Unity
        Quaternion gyroAttitude = context.ReadValue<Quaternion>();
        Quaternion unityRotation = new Quaternion(gyroAttitude.x, gyroAttitude.y, -gyroAttitude.z, -gyroAttitude.w);

        // Aplica la rotación a la caña de pescar
        transform.localRotation = unityRotation;

        // Ajusta la longitud de la línea de pesca basándose en la rotación
        float lengthFactor = CalculateLengthFactor(unityRotation);
        lineRenderer.SetPosition(1, new Vector3(0, -lengthFactor, 0));
    }

    // Método para calcular el factor de longitud basado en la rotación
    private float CalculateLengthFactor(Quaternion rotation)
    {
        // Implementa la lógica para calcular la longitud de la línea de pesca
        // Esto es solo un ejemplo y deberás ajustarlo según tu juego
        return Mathf.Abs(rotation.x) * maxLength;
    }
}
