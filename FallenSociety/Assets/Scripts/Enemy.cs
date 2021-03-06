using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    //Experience
    public int xpValue = 1;

    // Logic
    public float triggerDistance = 0.3f;
    public float chaseDistance = 2;
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;

    //Hitbox
    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {

        // Is the player in range to engage?
        if (Vector3.Distance(playerTransform.position, startingPosition) < chaseDistance)
        {
            if (Vector3.Distance(playerTransform.position, startingPosition) < triggerDistance)
                chasing = true;

            if (chasing)
            {
                if (!collidingWithPlayer)
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }
            }
            else
            {
                UpdateMotor(startingPosition - transform.position);
            }
        }
        else
        {
            UpdateMotor(startingPosition - transform.position);
            chasing = false;
        }

        //Check for overlaps
        collidingWithPlayer = false;
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            if (hits[i].tag == "Fighter" && hits[i].name == "Player")
            {
                collidingWithPlayer = true;
            }

            //Clean up collisions array at end of detection for that index
            hits[i] = null;

        }
    }

    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.GrantExp(xpValue);
        GameManager.instance.ShowText("+" + xpValue + " EXP", 22, Color.green, transform.position, Vector3.up * 40, 1.2f);
    }
}
