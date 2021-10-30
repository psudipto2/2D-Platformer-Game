using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownController : MonoBehaviour
{
    bool MoveUp = true;
    float MoveSpeed = 3f;

    private void Update()
    {

        if (transform.position.y < 0f)
        {
            MoveUp = true;
        }

        if (transform.position.y > 15f)
        {
            MoveUp = false;
        }

        if (MoveUp)

            transform.position = new Vector2(transform.position.x, transform.position.y + MoveSpeed * Time.deltaTime);

        else

            transform.position = new Vector2(transform.position.x, transform.position.y - MoveSpeed * Time.deltaTime);
    }
}
