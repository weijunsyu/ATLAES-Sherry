using UnityEngine;

public class PlayerAnimations : AbstractAnimations
{
    // Movements
    [Header("Player-Movements")]
    public Sprite[] idle;
    public Sprite[] walkForwards;
    public Sprite[] walkBackwards;
    public Sprite[] run;
    public Sprite[] crouch;
    public Sprite[] jump;
    public Sprite[] fall;
    public Sprite[] dash;
    public Sprite[] sprint;
    public Sprite[] slide;
    public Sprite[] slideJump;

    // Reactions
    [Header("Player-Reactions")]
    public Sprite[] burst;
    public Sprite[] standHitHigh;
    public Sprite[] standHit;
    public Sprite[] jumpHitHigh;
    public Sprite[] jumpHit;
    public Sprite[] crouchHitHigh;
    public Sprite[] crouchHit;
    public Sprite[] flip;
    public Sprite[] knockback;
    public Sprite[] knockbackFall;
    public Sprite[] knockdown;
    public Sprite[] recover;
    public Sprite[] death;

    // (u) Unarmed (Orb)
    [Header("Player-Unarmed")]
    public Sprite[] uCombatIdle;
    public Sprite[] uStandGuard;
    public Sprite[] uCrouchGuard;
    public Sprite[] uStrafe;
    public Sprite[] uStandBlock;
    public Sprite[] uCrouchBlock;
    public Sprite[] uStandLight;
    public Sprite[] uStandMedium;
    public Sprite[] uStandHeavy;
    public Sprite[] uCrouchLight;
    public Sprite[] uCrouchMedium;
    public Sprite[] uCrouchHeavy;
    public Sprite[] uJumpLight;
    public Sprite[] uJumpMedium;
    public Sprite[] uJumpHeavy;
    public Sprite[] uSpLowKick;
    public Sprite[] uSpSnapKick;
    public Sprite[] uSpVerticalKick;
    public Sprite[] uSpThrustKick;
    public Sprite[] uSpHookKick;
    public Sprite[] uSpAirDragonPunch;
    public Sprite[] uSpGroundDragonPunch;
    public Sprite[] uSpFeintRoll;
    public Sprite[] uSpAirAxeKick;
    public Sprite[] uSpRollingAxeKick;

    // (m) Magic Book

    // (g) Gun

    // (k) Katana

    // (b) Bastard Sword

    // (l) Greatsword

    // (d) Daggers and Knives

    // (s) Spear

    // (n) Naginata

    // (c) Cube [Nano blades and augmented human technology] Takes both weapon slots, newgame+ reward.
}
