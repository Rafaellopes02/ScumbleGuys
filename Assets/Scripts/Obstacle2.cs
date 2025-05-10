using UnityEngine;

public class Obstacle2 : MonoBehaviour
{
    private float timer = 0f;
    private bool isUp = false;

    private Vector3 visiblePosition;
    private Vector3 invisiblePosition;

    void Start()
    {
        // Define posições
        visiblePosition = new Vector3(transform.position.x, 0.3f, transform.position.z);
        invisiblePosition = new Vector3(transform.position.x, -3f, transform.position.z);

        // Começa na posição "invisível"
        transform.position = invisiblePosition;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (!isUp && timer >= 1f)
        {
            transform.position = visiblePosition;
            isUp = true;
            timer = 0f;
        }
        else if (isUp && timer >= 2f)
        {
            transform.position = invisiblePosition;
            isUp = false;
            timer = 0f;
        }
    }
}
