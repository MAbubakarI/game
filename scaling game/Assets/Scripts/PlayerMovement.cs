using UnityEditorInternal;
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
    private float wallJumpCooldown = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float xdir = Input.GetAxis("Horizontal");

        // face direction of movement
        if (xdir > 0.01f)
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        else if (xdir < 0.01f)
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);


        if (wallJumpCooldown > 0.2f)
        {
            rb.velocity = new Vector2(xdir * speed, rb.velocity.y);

            if (onWall() && !isGrounded())
            {
                rb.gravityScale = 0;
                rb.velocity = Vector2.zero;
            }
            else
                rb.gravityScale = 3;

            if (Input.GetKey(KeyCode.Space))
                Jump();
        }
        else
            wallJumpCooldown += Time.deltaTime;
    }

    private void Jump()
    {
        if (isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
        else if (onWall() && !isGrounded())
        {
            wallJumpCooldown = 0;
            rb.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
        }
    }

    private bool isGrounded()
    {
        // remember that 0 vector2.down is assuming boxcollider is straight and no rotation
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
