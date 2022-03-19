using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    private void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        UpdateMotor(new Vector3(moveX,moveY,0));
    }
}
