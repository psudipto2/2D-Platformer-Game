using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public Animator animator;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player_Controller player_Controller= collision.gameObject.GetComponent<Player_Controller>();
            player_Controller.pickUpKey();
            animator.SetInteger("Destroy", 1);
            Destroy(gameObject,0.1f);
        }
    }
}
