using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    private SpriteRenderer spriteRenderer;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();

        DontDestroyOnLoad(gameObject);
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        UpdateMotor(new Vector3(moveX,moveY,0));
    }

    public void SwapSprite(int skinID) 
    {
        spriteRenderer.sprite = GameManager.instance.playerSprites[skinID];
    }

    public void OnLevelUp()
    {
        maxHitPoints++;
        hitpoint = maxHitPoints;
    }

    public void SetLevel(int level) 
    {
        for (int i = 0; i < level; i++)
        {
            OnLevelUp();
        }
    }

}
