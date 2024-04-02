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
        // Carga el mapa de acciones 'Standard' y la acci�n 'Tilt'
        tiltAction = new InputActionMap("Standard").FindAction("Tilt");
    }

    void OnEnable()
    {
        // Habilita la acci�n de inclinaci�n y suscribe el m�todo correspondiente
        tiltAction.Enable();
        tiltAction.performed += OnTiltPerformed;
    }

    void OnDisable()
    {
        // Deshabilita la acci�n de inclinaci�n y desuscribe el m�todo
        tiltAction.Disable();
        tiltAction.performed -= OnTiltPerformed;
    }

    private void OnTiltPerformed(InputAction.CallbackContext context)
    {
        // Obtiene la actitud del giroscopio y la convierte en una rotaci�n de Unity
        Quaternion gyroAttitude = context.ReadValue<Quaternion>();
        Quaternion unityRotation = new Quaternion(gyroAttitude.x, gyroAttitude.y, -gyroAttitude.z, -gyroAttitude.w);

        // Aplica la rotaci�n a la ca�a de pescar
        transform.localRotation = unityRotation;

        // Ajusta la longitud de la l�nea de pesca bas�ndose en la rotaci�n
        float lengthFactor = CalculateLengthFactor(unityRotation);
        lineRenderer.SetPosition(1, new Vector3(0, -lengthFactor, 0));
    }

    // M�todo para calcular el factor de longitud basado en la rotaci�n
    private float CalculateLengthFactor(Quaternion rotation)
    {
        // Implementa la l�gica para calcular la longitud de la l�nea de pesca
        // Esto es solo un ejemplo y deber�s ajustarlo seg�n tu juego
        return Mathf.Abs(rotation.x) * maxLength;
    }
}
