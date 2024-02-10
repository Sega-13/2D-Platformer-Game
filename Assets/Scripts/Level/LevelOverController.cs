using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    public PlayerController playerController;
    private void Start()
    {
       // gameOverController = GetComponent<GameOverController>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
             Die();
        }
    }
    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    } 
    public void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.gameObject.GetComponent<PlayerController>() !=null)
         {
              CompleteLevel();
         }
    }

    private void CompleteLevel()
    {
        LevelManager.Instance.MarkCurrentLevelComplete();
        playerController.GameOverScreen();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
   /* private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/
}
