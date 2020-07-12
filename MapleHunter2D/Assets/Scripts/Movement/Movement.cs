using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody2D body = null;
    PlayerCharacterData playerCharacterData = null;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playerCharacterData = GetComponent<PlayerCharacterData>();
    }


    public bool Dash(float velocity, float duration)
    {
        if(body != null)
        {
            body.AddForce(new Vector2(velocity, 0), ForceMode2D.Impulse);
            return true;
        }

        return false;
    }

    public bool IsAirborne()
    {
        Vector2 currentVeclocity = body.velocity;
        if (currentVeclocity.y != 0)
        {
            return true;
        }
        return false;
    }
    public bool ForceStop()
    {
        return SetVelocity(0, 0);
    }
    public bool StopHorizontal()
    {
        if (playerCharacterData.canStop)
        {
            return SetHorizontal(0);
        }
        return false;
    }
    public bool StopVertical()
    {
        if (playerCharacterData.canStop)
        {
            return SetVertical(0);
        }
        return false;
    }
    public bool Strafe(float linearVelocity)
    {
        return SetHorizontal(linearVelocity);
    }
    public bool Move(float linearVelocity)
    {
        if (linearVelocity > 0) //move to the right
        {
            if (!playerCharacterData.facingRight) //currently facing left
            {
                Turn(); //turn to face right
            }
        }
        else //move to left
        {
            if (playerCharacterData.facingRight) //currently facing right
            {
                Turn(); //turn to face left
            }
        }
        return SetHorizontal(linearVelocity);
    }

    public bool Jump(float linearVelocity)
    {
        if (!this.IsAirborne())
        {
            return SetVertical(linearVelocity);
        }
        return false;
    }
    private bool SetVelocity(float xVelocity, float yVelocity)
    {
        if (body != null)
        {
            body.velocity = new Vector2(xVelocity, yVelocity);
            return true;
        }
        return false;
    }

    private bool AddVelocity(float xVelocity, float yVelocity)
    {
        if (body != null)
        {
            Vector2 currentVelocity = body.velocity;
            Vector2 newVelocity = new Vector2(currentVelocity.x + xVelocity, currentVelocity.y + yVelocity);
            body.velocity = newVelocity;
            return true;
        }
        return false;
    }

    private bool SetHorizontal(float xVelocity)
    {
        if (body != null)
        {
            Vector2 currentVelocity = body.velocity;
            Vector2 newVelocity = new Vector2(xVelocity, currentVelocity.y);
            body.velocity = newVelocity;
            return true;
        }
        return false;
    }
    private bool SetVertical(float yVelocity)
    {
        if (body != null)
        {
            Vector2 currentVelocity = body.velocity;
            Vector2 newVelocity = new Vector2(currentVelocity.x, yVelocity);
            body.velocity = newVelocity;
            return true;
        }
        return false;
    }
    private bool Turn()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            playerCharacterData.facingRight = !playerCharacterData.facingRight;
            return true;
        }
        return false;
    }
}
