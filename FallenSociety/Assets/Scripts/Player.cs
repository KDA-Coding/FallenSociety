using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    private SpriteRenderer spriteRenderer;
    private bool isAlive = true;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void ReceiveDamage(Damage dmg)
    {
        if (!isAlive) 
        {
            return;
        }
        base.ReceiveDamage(dmg);
        GameManager.instance.OnHipointChange();
    }

    protected override void Death()
    {
        isAlive = false;
        GameManager.instance.deathMenuAnimator.SetTrigger("Show");
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if(isAlive)
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

    public void Heal(int healAmount) 
    {
        if (hitpoint == maxHitPoints)
            return;

        hitpoint += healAmount;

        if (hitpoint > maxHitPoints)
            hitpoint = maxHitPoints;

        GameManager.instance.ShowText("+" + healAmount.ToString() + " HP", 22, Color.red, transform.position, Vector3.up * 30, 1.5f);
        GameManager.instance.OnHipointChange();
    }

    public void Respawn() 
    {
        Heal(maxHitPoints);
        isAlive = true;
        lastImmune = Time.time;
        pushDirection = Vector3.zero;
    }

}