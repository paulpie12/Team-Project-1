using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _horizontal;
    private bool _isFacingRight = true;
    //This integer controls how fast the player is once they exit the spindash
    private float startTime;

    public float jumpPower = 16f;
    public float speed = 8f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        //This code makes him move horizontally
        _horizontal = Input.GetAxisRaw("Horizontal");

        //Makes you jump longer
        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        flipplayer();
        
        //THIS IS THE JUMP CODE AND SPINDASH CODE ANYTHING THAT INVOLVES CROUCHING OR JUMPING NEEDS TO BE IN HERE 

        //This checks if they are pressing or releasing the jump button
        if (Input.GetButtonDown("Jump") || (Input.GetButtonUp("Jump")))
        {
            //This checks if they are grounded
            if (grounded())
            {
                //This is the spindash code, it is used when the player presses the jump button while grouned and holding down s/down arrow
                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    if (Input.GetButton("Jump"))
                    {
                        Debug.Log("Start of Spindash");
                        startTime = Time.time;
                    }
                    else if (Input.GetButtonUp("Jump"))
                    {
                        Debug.Log("End of Spindash, held down for " + (Time.time - startTime).ToString("00:00.00"));
                        //NONE OF THIS WORKS
                        //speed = 16f;
                        //trajectory();
                        //rb.AddForce(transform.right * 10f, ForceMode2D.Impulse);
                        //rb = GetComponent<Rigidbody2D>();
                        //rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                    }

                }
                //This is the jump code, it is used when they press jump and are grounded, but are not pressing s/down arrow
                else
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                }
            }
            
        }



    }
    //NONE OF THIS WORKS
    /*
    public void trajectory(Vector2 direction)
    {
        rb.AddForce(direction * this.speed);
    }
    */

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(_horizontal * speed, rb.velocity.y);
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
        }
    }
}