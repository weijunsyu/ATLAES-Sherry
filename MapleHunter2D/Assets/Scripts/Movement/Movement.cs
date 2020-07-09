using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private bool facingRight = true;
    public bool Stop()
    {
        return SetVelocity(0, 0);
    }
    public bool Strafe(float linearVelocity)
    {
        return AddVelocity(linearVelocity, 0);
    }

    public bool Move(float linearVelocity)
    {
        if (linearVelocity > 0) //move to the right
        {
            if (!facingRight) //currently facing left
            {
                Turn(); //turn to face right
            }
        }
        else //move to left
        {
            if (facingRight) //currently facing right
            {
                Turn(); //turn to face left
            }
        }
        return AddVelocity(linearVelocity, 0);
    }

    public bool Jump()
    {
        throw new NotImplementedException();
    }
    private bool SetVelocity(float xVelocity, float yVelocity)
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        if (body != null)
        {
            body.velocity = new Vector2(xVelocity, yVelocity);
            return true;
        }
        return false;
    }

    private bool AddVelocity(float xVelocity, float yVelocity)
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        if (body != null)
        {
            Vector2 currentVelocity = body.velocity;
            Vector2 newVelocity = new Vector2(currentVelocity.x + xVelocity, currentVelocity.y + yVelocity);
            body.velocity = newVelocity;
            return true;
        }
        return false;
    }

    private bool Turn()
    {
        throw new NotImplementedException();
    }
}
