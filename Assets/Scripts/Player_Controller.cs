using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Animator animator;
    [SerializeField]public float speed;
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        MoveCharacter(horizontal);
        PlayerAnimation(horizontal);
        //Input.GetKeyDown(KeyCode.Space);
    }

    private void MoveCharacter(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
    }

    private void PlayerAnimation(float horizontal)
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
    }
}
