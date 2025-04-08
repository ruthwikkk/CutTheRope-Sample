using UnityEngine;

public class BubbleController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float gravity = 0.1f;
    public GameObject ball;
    private Renderer renderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            LiftBubble();
        }

        if (collision.gameObject.tag == "Player")
        {
            DestroyBubble();
        }
    }

    void LiftBubble()
    {
        rigidbody.gravityScale = -gravity;
        ball.GetComponent<Rigidbody2D>().linearVelocityY = rigidbody.linearVelocity.y;
        ball.GetComponent<Rigidbody2D>().transform.position = transform.position;
        ball.GetComponent<Rigidbody2D>().gravityScale = rigidbody.gravityScale;
    }

    void DestroyBubble()
    {
        renderer.enabled = false;
        ball.GetComponent<Rigidbody2D>().gravityScale = 0.55f;
        Destroy(this);
    }
}
