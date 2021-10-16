using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Animator animator;
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -3f * Mathf.Abs(speed);
        }
        else if (speed > 0)
        {
            scale.x = 3*Mathf.Abs(speed);
        }
        transform.localScale = scale;
    }
}
