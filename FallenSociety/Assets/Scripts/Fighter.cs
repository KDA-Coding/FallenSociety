using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    //Public fighting character values
    public int hitpoint = 10;
    public int maxHitPoints = 10;
    public float pushRecoverySpeed = 0.2f;

    // Immunity time to prevent getting "stuck" or succumb to overlapping fire
    protected float immuneTime = 1.0f;
    protected float lastImmune;

    // Push vector for weapon knockback direction
    protected Vector3 pushDirection;


    //All fighters can ReceiveDamage / Die

    protected virtual void ReceiveDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 20, new Color(0.75f, 0.5f, 0.75f, 1.0f), 
                transform.position + new Vector3 (0, 0.1f, 0), Vector3.zero, 0.6f);


            if (hitpoint <= 0)
            {
                hitpoint = 0;
                Death();
            }
        }
    }

    protected virtual void Death() 
    {

    }
}
