using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControllerPuzzleScene : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float speed = 2.5f;
    private Rigidbody2D rb;
    private bool isInvincible = false;
    public bool isPlayerAlive;
    // public bool isPlayerAttacking;

    
    //controlling the animation
    Animator animator;

    public Slider healthBar;
    public float maxHealth = 100f;
    public float currentHealth;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.value = currentHealth;
        healthBar.maxValue = maxHealth;
        isPlayerAlive = true; 
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);


        //set animation parameters
        animator.SetFloat("Speed", movement.magnitude);
        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);
        UpdateHealthBar();

        if(healthBar.value <= 0) isPlayerAlive = false;

        if(Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Attack");
        }
    }

    public void TakeDamage(int amount)
    {
        if(isInvincible) return;


        currentHealth -= amount;
        healthBar.value = currentHealth;
        UpdateHealthBar();
        isInvincible = true;
        StartCoroutine(WaitForInvincibility());
    }

    private void UpdateHealthBar()
    {
        healthBar.value = currentHealth;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Rat"))
        {
            TakeDamage(10);
        }
    }

    private IEnumerator WaitForInvincibility()
    {
        yield return new WaitForSeconds(1f);
        isInvincible = false;
    }
}
