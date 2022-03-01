using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Animator animator;
    [SerializeField] float speed;
    [SerializeField] float jumpValue;
    private Rigidbody2D rb;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Loose"))
        {
            transform.position=new Vector3(14,-2,0);
            animator.SetInteger("Death", 1);
        }
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
            scale.x = -3f * Mathf.Abs(horizontal);
        }
        else if (horizontal > 0)
        {
            scale.x = 3 * Mathf.Abs(horizontal);
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
