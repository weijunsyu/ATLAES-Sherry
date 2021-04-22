using System.Collections.Generic;
using UnityEngine;

public class PlayerActionController : AbstractActionController
{
    public enum ComboInput
    {
        FORWARD_PRESS = 1,
        BACKWARD_PRESS = 2,
        CROUCH_PRESS = 3,
        UP_PRESS = 4,
        GUARD_PRESS = 5,
        JUMP_PRESS = 6,
        DASH_PRESS = 7,
        LIGHT_PRESS = 8,
        MEDIUM_PRESS = 9,
        HEAVY_PRESS = 10,
        FORWARD_RELEASE = -1,
        BACKWARD_RELEASE = -2,
        CROUCH_RELEASE = -3,
        UP_RELEASE = -4,
        GUARD_RELEASE = -5,
        JUMP_RELEASE = -6,
        DASH_RELEASE = -7,
        LIGHT_RELEASE = -8,
        MEDIUM_RELEASE = -9,
        HEAVY_RELEASE = -10,
    }

    public struct PlayerAction
    {
        public int[] inputSequence; //provided by the tree structure
        public bool isAirAction;
        public bool isChargeAction;
        public (PlayerActionController.ComboInput heldInput, double chargeTime) chargeInput;
        public float[] animationTimes;
        public float[] actionFrames;
        public double duration;
        public float hitstun;
        public float blockstun;
        public Vector2 forceOnUse; // force applied to player on action use (where positive is up and forwards)
        public Vector2 PushbackOnHit; // pushback on player if hit was successful (where pos. is towards hit location)
        public Vector2 forceOnTarget; // foce applied to the enemy on successful hit (where pos. is away from hit location)
    }
    public struct ActionTree
    {

    }

    // Config parameters:

    // Cached References:

    // State Parameters and Objects:
    private double timeCounter = 0d;
    [HideInInspector] public static Stack<(ComboInput input, double time)> inputBuffer = new Stack<(ComboInput input, double time)>();
    // Unarmed Actions (Light, Medium, Heavy) (Grounded, Airborne)
    [HideInInspector] public static List<PlayerAction> uLightGroundSpecials = new List<PlayerAction>();
    [HideInInspector] public static List<PlayerAction> uLightAirSpecials = new List<PlayerAction>();
    [HideInInspector] public static List<PlayerAction> uMediumGroundSpecials = new List<PlayerAction>();
    [HideInInspector] public static List<PlayerAction> uMediumAirSpecials = new List<PlayerAction>();
    [HideInInspector] public static List<PlayerAction> uHeavyGroundSpecials = new List<PlayerAction>();
    [HideInInspector] public static List<PlayerAction> uHeavyAirSpecials = new List<PlayerAction>();



    // Unity Events:
    protected override void Awake()
    {
        base.Awake();
        InitializeActions();
    }
    private void OnEnable()
    {
        // Enable player controller
        PlayerInputController.OnInputEvent += HandleInput;
    }
    private void Update()
    {
        timeCounter += Time.deltaTime;
    }
    private void OnDisable()
    {
        // Disable player controller
        PlayerInputController.OnInputEvent -= HandleInput;
    }

    // Class Functions:
    public void resetInputBuffer()
    {
        inputBuffer.Clear();
    }
    private void AddToBuffer(ComboInput input)
    {
        double currentTime = timeCounter;

        if (inputBuffer.Count > 0)
        {
            // If the time delta is larger than the max allowed time delta for input buffer
            if ((currentTime - inputBuffer.Peek().time) > GameConstants.INPUT_BUFFER_LIFESPAN)
            {
                inputBuffer.Clear(); // Reset the stack
                timeCounter = 0; // Reset the time counter
            }
        }
        inputBuffer.Push((input, currentTime));
    }

    private void HandleInput(object sender, InputEventArgs inputEvent)
    {
        switch (inputEvent.input)
        {
            case PlayerInputController.RawInput.RIGHT_PRESS:
                if (movementController.IsFacingRight())
                {
                    AddToBuffer(ComboInput.FORWARD_PRESS);
                }
                else
                {
                    AddToBuffer(ComboInput.BACKWARD_PRESS);
                }
                break;
            case PlayerInputController.RawInput.LEFT_PRESS:
                if (movementController.IsFacingRight())
                {
                    AddToBuffer(ComboInput.BACKWARD_PRESS);
                }
                else
                {
                    AddToBuffer(ComboInput.FORWARD_PRESS);
                }
                break;
            case PlayerInputController.RawInput.RIGHT_RELEASE:
                if (movementController.IsFacingRight())
                {
                    AddToBuffer(ComboInput.FORWARD_RELEASE);
                }
                else
                {
                    AddToBuffer(ComboInput.BACKWARD_RELEASE);
                }
                break;
            case PlayerInputController.RawInput.LEFT_RELEASE:
                if (movementController.IsFacingRight())
                {
                    AddToBuffer(ComboInput.BACKWARD_RELEASE);
                }
                else
                {
                    AddToBuffer(ComboInput.FORWARD_RELEASE);
                }
                break;
            default:
                AddToBuffer((ComboInput)inputEvent.input);
                break;
        }
    }
    private void InitializeActions()
    {

    }
}
