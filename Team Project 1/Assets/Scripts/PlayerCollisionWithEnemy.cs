using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionWithEnemy : MonoBehaviour
{
    //This creates a spot in unity to like the players rigidbody 2D to
    public Rigidbody2D rb2D;
    //Used to influence the amount of gems you lose on hit
    public int valuelost;

    //This code makes the player lose gems when hit from an enemy, and lose the game if you are on zero health
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            //I want this line to check if the current gems = 0
            if (GemCounter.currentGems == 0)
            {
                Debug.Log("The Game Ends");
                AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Lose screen");
            }

            Debug.Log("The Collision with an enemy is occurring");
            GemCounter.instance.DecreaseGems(valuelost);
        }
    }
}
