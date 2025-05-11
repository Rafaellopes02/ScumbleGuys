using UnityEngine;

public class Obstacle6 : MonoBehaviour
{
    public float speed = 4f;

    private Vector3 pointA;
    private Vector3 pointB;
    private bool movingToB = true;

    void Start()
    {
        // Define os dois pontos
        pointA = new Vector3(-27.10379287f, 20.435408f, 93.0106391f);
        pointB = new Vector3(-57.10379287f, 20.435408f, 93.0106391f);

        // Começa na posição inicial (A)
        transform.position = pointA;
    }

    void Update()
    {
        Vector3 target = movingToB ? pointB : pointA;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Quando chega ao destino, inverte a direção
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            movingToB = !movingToB;
        }
    }
}
