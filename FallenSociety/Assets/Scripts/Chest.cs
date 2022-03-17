using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int coinAmount = 5;


    protected override void OnCollect() 
    {
        if (!isCollected) 
        {
            isCollected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;

            //Statement to show currency text over Chests.
            GameManager.instance.ShowText("+"+coinAmount+" Coins", 24, Color.yellow, transform.position, Vector3.up * 40, 2.5f);
            //GameManager.instance.ShowText("+" + coinAmount + " coins", 22, Color.yellow, transform.position, Vector3.up * 40, 2.5f);
        }
    }

}
