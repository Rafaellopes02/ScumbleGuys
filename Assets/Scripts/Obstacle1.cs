using UnityEngine;

public class Obstacle1 : MonoBehaviour
{
    public float speed = 3f;      // Velocidade do movimento
    public float distance = 5f;   // Distância total que o cubo percorre para cada lado
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float x = Mathf.PingPong(Time.time * speed, distance) - distance / 2;
        transform.position = startPos + new Vector3(x, 0, 0);
    }
}
