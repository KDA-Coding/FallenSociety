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
    }

    protected override void ReceiveDamage(Damage dmg)
    {
        base.ReceiveDamage(dmg);
        GameManager.instance.OnHipointChange();
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
        Debug.Log("OnLevelUp() Called");
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

    public void Heal(int healAmount) 
    {
        if (hitpoint == maxHitPoints)
            return;

        hitpoint += healAmount;

        if (hitpoint > maxHitPoints)
            hitpoint = maxHitPoints;

        GameManager.instance.ShowText("+" + healAmount.ToString() + " HP", 22, new Color(0.9f, 0.2f, 0.1f), transform.position, Vector3.up * 30, 1.5f);
        GameManager.instance.OnHipointChange();
    }
}
