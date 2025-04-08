using UnityEngine;
using UnityEngine.SceneManagement;

public class SpiderController : MonoBehaviour
{
    public GameObject[] pathPoints;
    public float speed = 1f;
    private int currentPointIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject currentPoint = pathPoints[currentPointIndex];

        if (currentPoint != null && currentPointIndex + 1 <= pathPoints.Length)
        {
            Vector2 direction = currentPoint.transform.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, currentPoint.transform.position) < 0.1f)
            {
                currentPointIndex = (currentPointIndex + 1) % pathPoints.Length;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            // Get the current scene index
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Reload the current scene
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
