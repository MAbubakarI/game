using UnityEngine;

public class NPlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private bool grounded;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();

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
        if (Input.GetKey(KeyCode.Space) && grounded)
            body.velocity = new Vector2(body.velocity.x, speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = false;
    }
}
