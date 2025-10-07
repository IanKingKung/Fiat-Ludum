using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float speed = 2.5f;
    private Rigidbody2D rb;

    
    //controlling the animation
    Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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



    }
}
