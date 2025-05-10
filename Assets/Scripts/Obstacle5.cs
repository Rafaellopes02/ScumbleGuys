using UnityEngine;

public class Obstacle5 : MonoBehaviour
{
    public float rotationSpeed = 35f;

    void Update()
    {
        // Roda em torno do eixo Y continuamente
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
