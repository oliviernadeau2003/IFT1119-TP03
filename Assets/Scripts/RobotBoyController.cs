using UnityEngine;

public class RobotBoyController : MonoBehaviour
{
    public float speed = 35;
    public float impulsion = 15;

    float movement = 0;
    bool isJumping;
    int nbJump;
    Rigidbody2D rigidBody2D;
    SpriteRenderer spriteRenderer;
    Animator animator;

    void Start()
    {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();

        movement = 0;
        isJumping = false;
        nbJump = 0;
    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        animator.SetFloat("State", Mathf.Abs(movement));

        // X Rotation
        if (movement < 0)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;

        // Jump
        if (Input.GetKeyDown(KeyCode.W) && nbJump < 2)
        {
            isJumping = true;
            animator.SetTrigger("Jump");
            nbJump++;
        }
    }

    private void FixedUpdate()
    {
        rigidBody2D.AddRelativeForce(Vector2.right * speed * movement);

        if (isJumping)
        {
            rigidBody2D.AddRelativeForce(Vector2.up * impulsion, ForceMode2D.Impulse);
            isJumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        nbJump = 0;
    }
}