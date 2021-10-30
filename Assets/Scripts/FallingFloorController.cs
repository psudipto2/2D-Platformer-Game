using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloorController : MonoBehaviour
{
    public Rigidbody2D rb2d;

    private void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("fallDown");

        }

    }
    IEnumerator fallDown()
    {
        yield return new WaitForSeconds(1f);
        rb2d.isKinematic = false;
    }

}
