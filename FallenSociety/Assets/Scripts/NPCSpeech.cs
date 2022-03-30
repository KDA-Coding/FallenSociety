using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpeech : Collidable
{

    public string message;

    protected override void OnCollide(Collider2D coll)
    {
        GameManager.instance.ShowText(message, 25, Color.white, transform.position, Vector3.zero, 5.0f);
    }
}
