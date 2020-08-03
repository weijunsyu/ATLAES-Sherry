using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerAction : CharacterAction
{
    // Config parameters:

    // Cached References:
    [SerializeField] private GameObject attackOrigin = null;
    [SerializeField] private GameObject reticleObject = null;
    private Camera gameCamera;

    // State Parameters and Objects:
    private Vector2 mousePositionPixels = Vector2.zero;


    // Unity Events:
    protected override void Awake()
    {
        base.Awake();
        gameCamera = Camera.main;
    }
    private void Update()
    {
        Vector2 mousePositionWorld = gameCamera.ScreenToWorldPoint(mousePositionPixels);
        DrawReticle(mousePositionWorld);
        AimCharacterMouse(mousePositionWorld);
    }


    // Class Functions:
    public void DefendAction() //Do action part of defend
    {
        //create shield and start draining HP. Mitigate 100% damage, do not prevent knockbacks, successfully blocking regens some HP
    }
    public void SetReticleAndAim(Vector2 direction)
    {
        mousePositionPixels = direction;
    }
    private void DrawReticle(Vector2 worldDirection)
    {
        Vector3 newPos = new Vector3(worldDirection.x, worldDirection.y, reticleObject.transform.position.z);
        reticleObject.transform.position = newPos;
    }
    private void AimCharacterMouse(Vector2 worldDirection)
    {
        Vector3 origin = attackOrigin.transform.position;
        Vector2 unitDirection = CorrectMouseAimDirection(worldDirection);
        Vector2 initialVectorRaw = origin;
        Vector2 finalVectorRaw = new Vector2(origin.x + unitDirection.x, origin.y + unitDirection.y);
        Debug.DrawLine(initialVectorRaw, finalVectorRaw, Color.red, 0.5f);
    }
    public void AimCharacterJoystick(Vector2 direction)
    {
        Vector3 origin = attackOrigin.transform.position;
        Vector2 unitDirection = CorrectJoystickAimDirection(direction);
        Vector2 initialVectorRaw = origin;
        Vector2 finalVectorRaw = new Vector2(origin.x + unitDirection.x, origin.y + unitDirection.y);
        Debug.DrawLine(initialVectorRaw, finalVectorRaw, Color.red, 0.5f);
    }
    private Vector2 CorrectMouseAimDirection(Vector2 direction)
    {
        Vector3 origin = attackOrigin.transform.position;
        Vector2 initialVectorRaw = origin;
        Vector2 unitVector = StaticFunctions.UnitVector(direction - initialVectorRaw);
        return unitVector;
    }
    private Vector2 CorrectJoystickAimDirection(Vector2 direction)
    {
        //adjust joystick sensitivity (essentially creating artificial deadzone)
        if (StaticFunctions.VectorMagnitude(direction) < GameConstants.AIM_ATTACK_JOYSTICK_MIN_MAGNITUDE)
        {
            direction = Vector2.zero;
        }

        return StaticFunctions.UnitVector(direction);
    }
}
