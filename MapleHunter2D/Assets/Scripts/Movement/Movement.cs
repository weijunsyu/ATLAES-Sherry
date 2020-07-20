using UnityEngine;

public static class Movement
{
    public static bool IsAirborne(GameObject character)
    {
        Rigidbody2D body = character.GetComponent<Rigidbody2D>();
        Vector2 currentVeclocity = body.velocity;
        if (currentVeclocity.y != 0)
        {
            return true;
        }
        return false;
    }
    public static void StopHorizontal(GameObject character)
    {
        SetHorizontal(character, 0);
    }
    public static bool Move(GameObject character, float linearVelocity)
    {
        CharacterObjectData characterData = character.GetComponent<CharacterObjectData>();
        if (linearVelocity > 0) //move to the right
        {
            if (!characterData.isFacingRight) //currently facing left
            {
                Turn(character); //turn to face right
            }
        }
        else //move to left
        {
            if (characterData.isFacingRight) //currently facing right
            {
                Turn(character); //turn to face left
            }
        }
        return SetHorizontal(character, linearVelocity);
    }

    public static bool Jump(GameObject character, float linearVelocity)
    {
        if (!IsAirborne(character))
        {
            return SetVertical(character, linearVelocity);
        }
        return false;
    }
    private static bool SetHorizontal(GameObject character, float xVelocity)
    {
        Rigidbody2D body = character.GetComponent<Rigidbody2D>();
        if (body != null)
        {
            Vector2 currentVelocity = body.velocity;
            Vector2 newVelocity = new Vector2(xVelocity, currentVelocity.y);
            body.velocity = newVelocity;
            return true;
        }
        return false;
    }
    private static bool SetVertical(GameObject character, float yVelocity)
    {
        Rigidbody2D body = character.GetComponent<Rigidbody2D>();
        if (body != null)
        {
            Vector2 currentVelocity = body.velocity;
            Vector2 newVelocity = new Vector2(currentVelocity.x, yVelocity);
            body.velocity = newVelocity;
            return true;
        }
        return false;
    }
    private static bool Turn(GameObject character)
    {
        SpriteRenderer spriteRenderer = character.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            CharacterObjectData characterData = character.GetComponent<CharacterObjectData>();
            spriteRenderer.flipX = !spriteRenderer.flipX;
            characterData.isFacingRight = !characterData.isFacingRight;
            return true;
        }
        return false;
    }
}
