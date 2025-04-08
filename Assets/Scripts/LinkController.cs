using UnityEngine;

public class LinkController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DestroyRope();
            Destroy(this);
        }
    }

    void DestroyRope()
    {

        Transform parentTranform = transform.parent;
        if (parentTranform != null)
        {
            int childCount = parentTranform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                Transform child = parentTranform.GetChild(i);
                Destroy(child.gameObject);

            }
        }
    }
}
