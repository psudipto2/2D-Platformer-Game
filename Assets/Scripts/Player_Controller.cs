using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    public Animator animator;
    [SerializeField] float speed;
    [SerializeField] float jumpValue;
    private Rigidbody2D rb;
    public ScoreController scoreController;
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
        Debug.Log("Player Killed by enemy");
        animator.SetInteger("Death", 1);
        Destroy(gameObject, 2f);
        Reload();
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
