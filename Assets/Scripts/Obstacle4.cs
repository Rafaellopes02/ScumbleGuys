using UnityEngine;

public class Obstacle4 : MonoBehaviour
{
    private float timer = 0f;
    private bool isUp = false;

    private Vector3 visiblePosition;
    private Vector3 invisiblePosition;

    void Start()
    {
        // Define posi��es
        visiblePosition = new Vector3(transform.position.x, 0.3f, transform.position.z);
        invisiblePosition = new Vector3(transform.position.x, -3f, transform.position.z);

        // Come�a na posi��o "invis�vel"
        transform.position = invisiblePosition;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (!isUp && timer >= 3f)
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
