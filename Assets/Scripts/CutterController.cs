using UnityEngine;
using UnityEngine.InputSystem;

public class CutterController : MonoBehaviour
{
    public GameObject objectToIgnore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (objectToIgnore != null)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), objectToIgnore.GetComponent<Collider2D>(), true);
        }
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 screenPosition;

        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            screenPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        }
        else if (Mouse.current != null && Mouse.current.leftButton.isPressed)
        {
            screenPosition = Mouse.current.position.ReadValue();
        }
        else
        {
            return; // no input
        }

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        worldPosition.z = 0f; // make sure it's set properly for your use case
        transform.position = worldPosition;
    }
}
