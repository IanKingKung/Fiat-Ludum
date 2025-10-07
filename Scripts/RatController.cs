using UnityEngine;


public class RatController : MonoBehaviour
{
    private Animator animator;
    public GameObject player;
    private Rigidbody2D rb;
    public float speed = 3f;
    private Vector2 lastPosition;
    private bool isAttacking = false;
    public bool isAttackingPlayer = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        lastPosition = rb.position;
    }


    void FixedUpdate()
    {
        if (player == null) return;

        Vector2 direction = ((Vector2)player.transform.position - rb.position).normalized;
        rb.linearVelocity = direction * speed;

        if (Vector2.Distance(rb.position, player.transform.position) < 0.5f)
        {
            rb.linearVelocity = Vector2.zero;
        }

        float movementSpeed = (rb.position - lastPosition).magnitude / Time.fixedDeltaTime;
        animator.SetFloat("Speed", movementSpeed);
        animator.SetBool("IsAttacking", isAttacking);

        lastPosition = rb.position;

        if(isAttackingPlayer && Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isAttacking = true;
            AttackPlayer();
            isAttackingPlayer = true;
        }
    }

    private void AttackPlayer()
    {
        //do something so that the rat can take out the player's health every 3 seconds
    }

}
