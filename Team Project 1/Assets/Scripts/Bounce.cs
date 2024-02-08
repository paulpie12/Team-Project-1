using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bounce;
    public Rigidbody2D rb2D;
    

        private void OnCollisionEnter2D(Collision2D collision)
        {
        //This checks if the collision
            if (collision.gameObject.CompareTag("Enemy"))
            {
            Debug.Log("The Collision is occurring");
            Destroy(collision.gameObject);
            rb2D.velocity = new Vector2(rb2D.velocity.x, bounce);
            }  
        }
    }

/*
private void Update()
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("The Collision is occurring");
        }
    }
}

}
  */
