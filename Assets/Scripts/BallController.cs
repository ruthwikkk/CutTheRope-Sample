using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    private Collider2D collider;
    private Renderer objectRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collider = GetComponent<Collider2D>();
        objectRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Character")
        {
            collider.enabled = false;
            objectRenderer.enabled = false;
            SceneController.instance.NextLevel();
        }

        if (collision.gameObject.name == "Ground" ||
            collision.gameObject.name == "Obstacle" || collision.gameObject.tag == "Obstacle")
        {
            // Get the current scene index
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Reload the current scene
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
