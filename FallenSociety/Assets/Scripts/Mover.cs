using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{

    protected BoxCollider2D boxCollider;

    protected Vector3 moveDelta;
    protected RaycastHit2D hit;
    protected float ySpeed = 0.75f;
    protected float xSpeed = 1.0f;


    private Vector2 colScale = new Vector2(0.7f, 0.7f);

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void UpdateMotor(Vector3 input) 
    {
        //Reset moveDelta
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

        //Switch Sprite facing based on move direction (Right or Left)
        if (moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Check if we can move in this direction by casting a box collider in that direction first.
        // If box collider returns null, we can move.
        hit = Physics2D.BoxCast(transform.position, boxCollider.size * colScale, 0, new Vector2(0, moveDelta.y),
            Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            //Move the player sprite along y axis
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size * colScale, 0, new Vector2(moveDelta.x, 0),
            Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            //Move the player sprite along x axis
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }


        //Debugs for Movement floats
        /*
        Debug.Log(moveX);
        Debug.Log(moveY); */
    }

}
