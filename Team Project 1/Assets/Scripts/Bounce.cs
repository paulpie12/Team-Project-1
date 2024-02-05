using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    //This Variable changes the bounce height
    public float bounce;
    //This creates a spot in unity to like the players rigidbody 2D to
    public Rigidbody2D rb2D;

    //This checks if the collision is with an enemy tag, and if it is, then is destroys the object and makes the player character bounce
    private void OnCollisionEnter2D(Collision2D collision)
        {
        
            if (collision.gameObject.CompareTag("Enemy"))
            {
            Debug.Log("The Collision is occurring");
            Destroy(collision.gameObject);
            rb2D.velocity = new Vector2(rb2D.velocity.x, bounce);
            }  
        }
    }
