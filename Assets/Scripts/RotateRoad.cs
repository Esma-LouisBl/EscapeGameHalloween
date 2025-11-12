using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [Header("Rotation Settings")]
    [Tooltip("Vitesse de rotation en degrés par seconde")]
    public float rotationSpeed = 90f;

    [Tooltip("Axe de rotation (X, Y, Z)")]
    public Vector3 rotationAxis = Vector3.up;

    void Update()
    {
        // Fait tourner l’objet en fonction du temps et de la vitesse
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
