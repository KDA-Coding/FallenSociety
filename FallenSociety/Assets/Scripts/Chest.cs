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
            Debug.Log("Granted " + coinAmount + " coins!");
        }
    }

}
