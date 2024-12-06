using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RobotBoyController : MonoBehaviour
{
    public float speed = 35;
    public float impulsion = 15;

    public GameObject healthUI;
    public AudioClip deathSound;

    int hp = 1;
    float movement = 0;
    bool isJumping;
    bool isCrouching;
    bool isRolling;
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

        // Crounching
        if (Input.GetKeyDown(KeyCode.S))
        {
            isCrouching = true;
            animator.SetBool("Crouch", true);
            speed /= 2;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            isCrouching = false;
            animator.SetBool("Crouch", false);
            speed *= 2;
        }

        // Rolling
        if (Input.GetKeyDown(KeyCode.X))
        {
            isRolling = true;
            animator.SetTrigger("Roll");
        }
    }

    private void FixedUpdate()
    {
        rigidBody2D.AddRelativeForce(movement * speed * Vector2.right);

        if (isJumping)
        {
            rigidBody2D.AddRelativeForce(Vector2.up * impulsion, ForceMode2D.Impulse);
            isJumping = false;
        }
        else if (isCrouching)
        { }
        else if (isRolling)
        {
            if (movement < 0)
                rigidBody2D.AddRelativeForce(Vector2.left * impulsion, ForceMode2D.Impulse);
            else
                rigidBody2D.AddRelativeForce(Vector2.right * impulsion, ForceMode2D.Impulse);

            isRolling = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        nbJump = 0;
        CollisionManager(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollisionManager(collision.gameObject);
    }

    private void CollisionManager(GameObject gameObject)
    {
        if (gameObject.CompareTag("Bonus"))
        {
            hp++;
            HealthDisplayUpdate();
        }
        if (gameObject.CompareTag("Malus"))
        {
            hp--;
            HealthDisplayUpdate();
        }
        if (gameObject.CompareTag("Mortem") || hp == 0)
        {
            hp = 0;
            HealthDisplayUpdate();

            onDeath();
        }
    }

    private void HealthDisplayUpdate()
    {
        healthUI.GetComponent<RectTransform>().localScale = new Vector3(hp, 1f, 1f);
        healthUI.GetComponent<RawImage>().uvRect = new Rect(0, 0, hp, 1f);
    }

    private void onDeath()
    {
        // Play DeathAnimation
        // Stop movement
        speed = 0;
        impulsion = 0;
        rigidBody2D.simulated = false;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        animator.SetTrigger("Death");

        gameObject.GetComponent<AudioSource>().Stop();
        gameObject.GetComponent<AudioSource>().PlayOneShot(deathSound);

        //Wait 7 seconds then restart game
        Invoke(nameof(Restart),7f);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}