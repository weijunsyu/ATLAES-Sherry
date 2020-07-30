using UnityEngine;

public class PlayerCharacterLogic : CharacterObjectLogic
{
    // Config parameters:
    [SerializeField] public float jumpVelocity = 4f;
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float dashSpeed = 20f;
    [SerializeField] private float canJumpDelayAfterAirborneInSeconds = 0.125f;

    // Cached References:
    [SerializeField] private InputController playerController = null;
    [SerializeField] private Camera gameCamera = null;

    // State Parameters and Objects:
    public bool playerHasControl = true; //true if player has control over character (user input is accepted), false otherwise
    private int airJumpsPerformed = 0;
    private float canGroundJumpAfterAirborneTimer = 0; //timer run after initial airborne transition to determine if player can still jump
    private bool groundedJumpPerformed = false;

    // Stats
    private int level = 0;

    //Skills
    private int maxAirJumps = 1;

    private void Update()
    {
        playerController.ReEvaluateMovementInput(); //evaluate movement every frame udpate
    }

    private void FixedUpdate()
    {
        if (!UpdateAirborne()) //check if player is airborne every physics update
        {
            ResetAirJumps();
            if (canGroundJumpAfterAirborneTimer > canJumpDelayAfterAirborneInSeconds) //prevent resetting while in air due to airborne check height
            {
                canGroundJumpAfterAirborneTimer = 0; //reset canGroundJumpAfterAirborneTimer
                groundedJumpPerformed = false; //reset ground jump counter
            }
        }
        else // player went airborne
        {
            canGroundJumpAfterAirborneTimer += Time.fixedDeltaTime;
        }
    }

    //Aim
    public void AimCharacter(Vector2 direction)
    {
        Vector2 initialVectorRaw = transform.position;
        Vector2 finalVectorRaw = new Vector2(transform.position.x + direction.x, transform.position.y + direction.y);
        Debug.DrawLine(initialVectorRaw, finalVectorRaw, Color.red, 0.5f);
    }
    public Vector2 CorrectPixelAimDirection(Vector2 direction)
    {
        Vector2 worldDirection = gameCamera.ScreenToWorldPoint(direction);
        Vector2 initialVectorRaw = transform.position;
        Vector2 unitVector = StaticFunctions.UnitVector(worldDirection - initialVectorRaw); 
        return unitVector;
    }
    public Vector2 CorrectJoystickAimDirection(Vector2 direction)
    {
        return StaticFunctions.UnitVector(direction);
    }

    //Movement
    public void MoveWithTurn(float linearVelocity)
    {
        if (linearVelocity > 0) //move to the right
        {
            if (!isFacingRight) //currently facing left
            {
                Turn(); //turn to face right
            }
        }
        else //move to left
        {
            if (isFacingRight) //currently facing right
            {
                Turn(); //turn to face left
            }
        }
        SetHorizontal(linearVelocity);
    }
    public void Jump(float linearVelocity)
    {

        if (!groundedJumpPerformed && (canGroundJumpAfterAirborneTimer < canJumpDelayAfterAirborneInSeconds))
        {
            SetVertical(linearVelocity);
            groundedJumpPerformed = true;
        }
        else
        {
            if (airJumpsPerformed++ < maxAirJumps)
            {
                SetVertical(linearVelocity);
            }
            else //prevent integer overflow (from spamming jump in air)
            {
                airJumpsPerformed = maxAirJumps;
            }
        }
    }
    public void StopHorizontal()
    {
        SetHorizontal(0);
    }
    private void ResetAirJumps()
    {
        airJumpsPerformed = 0;
    }
}
