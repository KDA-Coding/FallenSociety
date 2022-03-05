using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    private Vector3 moveDelta;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        //Reset moveDelta
        moveDelta = new Vector3(moveX, moveY, 0);

        //Switch Sprite facing based on move direction (Right or Left)
        if (moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0) 
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //Move the player sprite
        transform.Translate(moveDelta * Time.deltaTime);

        
        //Debugs for Movement floats
        /*
        Debug.Log(moveX);
        Debug.Log(moveY); */
    }
}
