using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    public Animator animator;
    [SerializeField] float speed;
    [SerializeField] float jumpValue;
    private Rigidbody2D rb;
    public ScoreController scoreController;

    private int health = 3;
    private int numOfHearts = 3;
    public Image[] heart;
    public Sprite FullHeart;
    public Sprite BlankHeart;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Loose"))
        {
            transform.position=new Vector3(14,-2,0);
            animator.SetInteger("Death", 1);
            Destroy(gameObject, 2f);
            Reload();
        }
    }

    internal void pickUpKey()
    {
        Debug.Log("Key is picked up by the Player");
        scoreController.increaseScore(10);
    }

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float jump = Input.GetAxisRaw("Jump");
        float crouch = Input.GetAxisRaw("Fire1");
        MoveCharacter(horizontal,jump);
        PlayerAnimation(horizontal,jump,crouch);
        //Input.GetKeyDown(KeyCode.Space);
    }

    internal void killPlayer()
    {
        
        //Destroy(gameObject, 2f);
        if (health == 1)
        {
            Debug.Log("Player Killed by enemy");
            animator.SetInteger("Death", 1);
            Reload();
        }
        else
        {
            Debug.Log("Player Hitted by enemy");
            ReduceHealth();
        }
    }

    private void ReduceHealth()
    {
        health--;
        for (int i = 0; i < heart.Length; i++)
        {
            if (i < health)
            {
                heart[i].sprite = FullHeart;
            }
            else
            {
                heart[i].sprite = BlankHeart;
            }
        }
    }

    private void Reload()
    {
        SceneManager.LoadScene(0);
    }

    private void MoveCharacter(float horizontal,float vertical)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
        if (vertical > 0)
        {
            rb.AddForce(new Vector2(0f, jumpValue), ForceMode2D.Force);
        }
    }

    private void PlayerAnimation(float horizontal,float jump,float crouch)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -2f * Mathf.Abs(horizontal);
        }
        else if (horizontal > 0)
        {
            scale.x = 2 * Mathf.Abs(horizontal);
        }
        transform.localScale = scale;
        
        if (jump > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        if (crouch > 0)
        {
            animator.SetBool("Crouch", true);
        }
        else
        {
            animator.SetBool("Crouch", false);
        }
    }
}
