using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Animator animator;
    private Collider2D collider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            collider.enabled = false;
            animator.SetTrigger("BiteCollision");
        }
    }
}
