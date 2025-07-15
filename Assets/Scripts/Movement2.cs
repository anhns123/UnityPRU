using UnityEngine;

public class Movement2 : MonoBehaviour
{

    // Input key thiết lập từ Inspector
    public string horizontalInput;     // Tên của input axis cho di chuyển ngang
    public KeyCode jumpKey;            // Phím nhảy
    public KeyCode attackKey;          // Phím tấn công
    public KeyCode skillKey;           // Phím bắn phép

    // Các biến điều khiển chuyển động
    public float speed = 5f;
    public float jumpForce = 12f;

    private Rigidbody2D rb;
    private Animator anim;

    public Transform groundCheck;
    public LayerMask groundLayer;

    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Lấy giá trị input di chuyển ngang
        float move = Input.GetAxisRaw(horizontalInput);
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        // Flip sprite theo hướng
        if (move != 0)
        {
            transform.localScale = new Vector3(move > 0 ? 1 : -1, 1, 1);
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        // Kiểm tra đang chạm đất
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // Nhảy
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            anim.SetTrigger("Jump");
        }

        // Tấn công
        if (Input.GetKeyDown(attackKey))
        {
            anim.SetTrigger("Attack");
        }

        // Skill bắn đạn
        if (Input.GetKeyDown(skillKey))
        {
            // code bắn đạn phép
        }
    }
}
