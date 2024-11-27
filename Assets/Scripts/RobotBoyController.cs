using UnityEngine;

public class RobotBoyController : MonoBehaviour
{
    public float speed = 50;
    public float impulsion = 0;

    float movement = 0;
    bool isJumping;
    int nbJump;
    Rigidbody2D rigidBody2D;
    SpriteRenderer spriceRenderer;
    Animator animator;

    void Start()
    {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        spriceRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();

        movement = 0;
        isJumping = false;
        nbJump = 0;
    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rigidBody2D.AddRelativeForce(Vector2.right * speed * movement);
        
    }
}
