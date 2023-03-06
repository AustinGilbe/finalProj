using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Made by Maria
public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap")) 
        {
            Die();
        }
    }

    private void Die()
    {
        body.bodyType = RigidbodyType2D.Static; //So the player cant move after death
        anim.SetTrigger("death");
    }


    
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Reloads the level
    }
}
