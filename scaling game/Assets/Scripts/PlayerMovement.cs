using UnityEngine;

public class NPlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpHangTimeThreshold;
    [SerializeField] private float jumpHangTimeMult;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float ydir = Input.GetAxis("Horizontal");

        // horizontal movement
        rb.velocity = new Vector2(ydir*speed, rb.velocity.y);

        // face direction of movement
        if (ydir > 0.01f)
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
        else if (ydir > 0.01f)
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);


        bool isGrounded = groundCheck();

        // jump
        if (Input.GetKey(KeyCode.Space) && isGrounded)
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
    }

    private bool groundCheck()
    {
        // remember that 0 vector2.down is assuming boxcollider is straight and no rotation
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
