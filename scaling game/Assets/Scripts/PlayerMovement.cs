using UnityEngine;

public class NPlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float ydir = Input.GetAxis("Horizontal");

        // horizontal movement
        body.velocity = new Vector2(ydir*speed, body.velocity.y);

        // face direction of movement
        if (ydir > 0.01f)
            transform.localScale = Vector3.one;
        else if (ydir > 0.01f)
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);

        // jump
        if (Input.GetKey(KeyCode.Space) && isGrounded())
            body.velocity = new Vector2(body.velocity.x, speed);
    }

    private bool isGrounded()
    {
        // remember that 0 vector2.down is assuming boxcollider is straight and no rotation
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
