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
    [SerializeField] float RunSpeed;
    [SerializeField] float jumpValue;
    private Rigidbody2D rb;



    public ScoreController scoreController;
    public GameOverController gameOverController;
    public bool onGround = false;
    public float jumpLength;
    public LayerMask groundLayer;
    private int health = 3;
    public Image[] heart;
    public Sprite FullHeart;
    public Sprite BlankHeart;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Loose"))
        {
            rb.velocity = new Vector2(-10f, 15f);
            StartCoroutine("waitBeforeShow");
            animator.SetInteger("Death", 1);
            StartCoroutine("waitBeforeShow");
            this.enabled = false;
            gameOverController.PlayerDied();
        }
    }
   /* private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Loose"))
        {
            rb.velocity = new Vector2(-2f, 6f);
            animator.SetInteger("Death", 1);
            this.enabled = false;
            gameOverController.PlayerDied();
        }
    }
   */
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
        onGround = Physics2D.Raycast(transform.position, Vector2.down, jumpLength, groundLayer);

        float run = Input.GetAxisRaw("Fire3");
        float horizontal = Input.GetAxisRaw("Horizontal");
        playMovementAnimation(horizontal,run);

        bool crouch = Input.GetKey(KeyCode.LeftControl);
        crouchAnimation(crouch);

        float vertical = Input.GetAxisRaw("Vertical");
        jumpAnimation(vertical);
        moveCharacter(horizontal,run);
    }

    private void FixedUpdate()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        characterJump(vertical);
    }
    private void jumpAnimation(float vertical)
    {
        animator.SetBool("Jump", vertical > 0);
    }

    private void crouchAnimation(bool crouch)
    {
        animator.SetBool("Crouch", crouch);
    }

    private void moveCharacter(float horizontal,float run)
    {


        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        if (run >= 1)
        {
            position.x += horizontal * RunSpeed * Time.deltaTime;
        }
         //speed*(1/(30/sec)), 30fps
        transform.position = position;
    }
    private void characterJump(float vertical)
    {
        if (vertical > 0 && onGround)
        {
            Vector2 movement = new Vector2(rb.velocity.x, jumpValue);
            rb.velocity = movement;

        }
    }

    internal void killPlayer()
    {
        
        
        if (health < 1)
        {
            Debug.Log("Player Killed by enemy");
            StartCoroutine("waitBeforeShow");
            animator.SetInteger("Death", 1);
            StartCoroutine("waitBeforeShow");
            this.enabled = false;
            StartCoroutine("waitBeforeShow");
            gameOverController.PlayerDied();
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
    private void playMovementAnimation(float horizontal,float run)
    {

        {
            if (run>=1)
            {
                animator.SetFloat("Speed", Mathf.Abs(horizontal*2));
            }
            else
            {
                animator.SetFloat("Speed", Mathf.Abs(horizontal));
            }
            //animator.SetFloat("Speed", Mathf.Abs(horizontal));
            Vector3 scale = transform.localScale;
            scale.x = (horizontal < 0 ? -1f : (horizontal > 0 ? 1f : (scale.x / Mathf.Abs(scale.x)))) * Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }


      /*  private void PlayerAnimation(float horizontal,float jump,float crouch)
    {
        if (Input.GetAxisRaw("Fire3") > 0)
        {
            animator.SetFloat("Speed", Math.Abs(horizontal)*2);
        }
        animator.SetFloat("Speed", Math.Abs(horizontal));
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
            animator.SetInteger("Jump", 1);
        }
        else
        {
            animator.SetInteger("Jump", 0);
        }

        if (crouch > 0)
        {
            animator.SetInteger("Crouch", 1);
        }
        else
        {
            animator.SetInteger("Crouch", 0);
        }
    }*/
    IEnumerator waitBeforeShow()
    {
        yield return new WaitForSeconds(1f);
    }
}
