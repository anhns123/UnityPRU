using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    bool isGrounded = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
            isGrounded = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
            isGrounded = false;
    }

    public bool isCheckGrounded() { return isGrounded; }
}
