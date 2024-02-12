using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("You win the game");
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("WinScene");
    }
}
