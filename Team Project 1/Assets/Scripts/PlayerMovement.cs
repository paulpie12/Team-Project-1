using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _horizontal;
    private bool _isFacingRight = true;
    private bool _doubleJump;
    Animator animator;

    private float _initalGravityScale;

    //This integer controls how fast the player is once they exit the spindash
    private float startTime;

    //This bool controls player movement
    private bool movementControl = true;

    public float jumpPower = 16f;
    public float speed = 8f;
    [SerializeField] private float _glidingSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private void Start()

    {
        _initalGravityScale = rb.gravityScale;
    }

    void Update()
    {
        animator = GetComponent<Animator>();
        if(movementControl == true)
        {
            var glidingInput = Input.GetButton("Jump");

            //Gliding
            if (glidingInput && rb.velocity.y <= 0)
            {
                rb.gravityScale = 0;
                rb.velocity = new Vector2(rb.velocity.x, -_glidingSpeed);
                animator.SetFloat("MoveX", 0);
                animator.SetFloat("MoveY", -1);
            }
            else
            {
                rb.gravityScale = _initalGravityScale;
            }

            //jumping 

            _horizontal = Input.GetAxisRaw("Horizontal");

            if (grounded() && !Input.GetButton("Jump"))
            {
                _doubleJump = false;
            }

            if (Input.GetButtonDown("Jump"))
            {
                if (grounded() || _doubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                    animator.SetFloat("MoveX", 0);
                    animator.SetFloat("MoveY", 1);

                    _doubleJump = !_doubleJump;
                }
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

            flipplayer();
        }
        

        //This is the code for the spindash
        if (grounded())
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Debug.Log("Start of Spindash");
                startTime = Time.time;
                movementControl = false;
                animator.SetFloat("MoveX", 1);
                  animator.SetFloat("MoveY", 1);

            }
            else if (Input.GetKeyUp(KeyCode.Z))
            {
                Debug.Log("End of Spindash, held down for " + (Time.time - startTime).ToString("00:00.00"));
                movementControl = true;
                rb.AddForce(transform.up * 35f, ForceMode2D.Impulse);
            }
        }
    }
    
    private void FixedUpdate()
    {
        if (movementControl == true)
        {
            rb.velocity = new Vector2(_horizontal * speed, rb.velocity.y);
        }
        
    }

    private bool grounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void flipplayer()
    {
        if (_isFacingRight && _horizontal < 0f || !_isFacingRight && _horizontal > 0f)
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            animator.SetFloat("MoveX", 1);
            animator.SetFloat("MoveY", 0);
        }
    }
}