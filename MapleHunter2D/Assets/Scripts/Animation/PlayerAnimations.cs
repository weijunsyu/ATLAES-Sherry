using UnityEngine;

public class PlayerAnimations : AbstractAnimations
{
    // Movements
    [Header("Player-Movements Spritesheet")]
    public Sprite[] idle;               // 2 key frames [ 0 - 1 ]
    public Sprite[] walkForwards;       // 8 key frames [ 2 - 9 ]
    public Sprite[] walkBackwards;      // 8 key frames [ 10 - 17 ]
    public Sprite[] run;                // 8 key frames [ 18 - 25 ]
    public Sprite[] crouch;             // 1 key frames [ 26 ]
    public Sprite[] jump;               // 2 key frames [ 27 - 28 ]
    public Sprite[] fall;               // 2 key frames [ 29 - 30 ]
    public Sprite[] dash;               // 6 key frames [ 31 - 36 ]
    public Sprite[] slide;              // 2 key frames [ 37 - 38 ]
    public Sprite[] slideJump;          // 1 key frames [ 39 ]

    // Reactions
    [Header("Player-Reactions Spritesheet")]
    public Sprite[] burst;              // 2 key frames [0 - 1]
    public Sprite[] standHitHigh;       // 1 key frames [ 2 ]
    public Sprite[] standHit;           // 1 key frames [ 3 ]
    public Sprite[] jumpHitHigh;        // 1 key frames [ 4 ]
    public Sprite[] jumpHit;            // 1 key frames [ 5 ]
    public Sprite[] crouchHitHigh;      // 1 key frames [ 6 ]
    public Sprite[] crouchHit;          // 1 key frames [ 7 ]
    public Sprite[] airRoll;            // 4 key frames [ 8 - 11 ]
    public Sprite[] knockback;          // 1 key frames [ 12 ]
    public Sprite[] knockbackFall;      // 1 key frames [ 13 ]
    public Sprite[] knockdown;          // 1 key frames [ 14 ]
    public Sprite[] recover;            // 1 key frames [ 15 ]
    public Sprite[] death;              // 8 key frames [ 16 - 23 ]

    // (u) Unarmed (Orb)
    [Header("Player-Unarmed Spritesheet")]
    public Sprite[] uCombatIdle;            // 2 key frames [ 0 - 1 ]
    public Sprite[] uStandGuard;            // 2 key frames [ 2 - 3 ]
    public Sprite[] uCrouchGuard;           // 1 key frames [ 4 ]
    public Sprite[] uJumpGuard;             // 1 key frames [ 5 ]
    public Sprite[] uStrafe;                // 2 key frames [ 6 - 7 ]
    public Sprite[] uStandBlock;            // 1 key frames [ 8 ]
    public Sprite[] uCrouchBlock;           // 1 key frames [ 9 ]
    public Sprite[] uJumpBlock;             // 1 key frames [ 10 ]
    public Sprite[] uStandLight;            // 2 key frames [ 11 - 12 ]
    public Sprite[] uStandMedium;           // 3 key frames [ 13 - 15 ]
    public Sprite[] uStandHeavy;            // 3 key frames [ 16 - 18 ]
    public Sprite[] uCrouchLight;           // 2 key frames [ 19 - 20 ]
    public Sprite[] uCrouchMedium;          // 3 key frames [ 21 - 23 ]
    public Sprite[] uCrouchHeavy;           // 3 key frames [ 24 - 26 ]
    public Sprite[] uJumpLight;             // 2 key frames [ 27 - 28 ]
    public Sprite[] uJumpMedium;            // 3 key frames [ 29 - 31 ]
    public Sprite[] uJumpHeavy;             // 2 key frames [ 32 - 33 ]
    public Sprite[] uSpLowKick;             // 4 key frames [ 34 - 37 ]
    public Sprite[] uSpSnapKick;            // 4 key frames [ 38 - 41 ]
    public Sprite[] uSpVerticalKick;        // 4 key frames [ 42 - 45 ]
    public Sprite[] uSpThrustKick;          // 5 key frames [ 46 - 50 ]
    public Sprite[] uSpHookKick;            // 5 key frames [ 51 - 55 ]
    public Sprite[] uSpAirDragonPunch;      // 3 key frames [ 56 - 58 ]
    public Sprite[] uSpGroundDragonPunch;   // 3 key frames [ 59 - 61 ]
    public Sprite[] uSpFeintRoll;           // 4 key frames [ 62 - 65 ]
    public Sprite[] uSpAirAxeKick;          // 5 key frames [ 66 - 70 ]
    public Sprite[] uSpRollingAxeKick;      // 8 key frames [ 71 - 78 ]

    // (m) Magic Book

    // (g) Gun

    // (k) Katana

    // (b) Bastard Sword

    // (l) Greatsword

    // (d) Daggers and Knives

    // (s) Spear

    // (n) Naginata

    // (c) Cube [nano blades and augmented human technology]
}
