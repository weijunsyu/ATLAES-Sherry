using UnityEngine;

public class PlayerAnimations : AbstractAnimations
{
    // Basic
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
    public Sprite[] standHitHigh;       // 1 key frames [ 40 ]
    public Sprite[] standHit;           // 1 key frames [ 41 ]
    public Sprite[] jumpHitHigh;        // 1 key frames [ 42 ]
    public Sprite[] jumpHit;            // 1 key frames [ 43 ]
    public Sprite[] crouchHitHigh;      // 1 key frames [ 44 ]
    public Sprite[] crouchHit;          // 1 key frames [ 45 ]
    public Sprite[] knockback;          // 1 key frames [ 46 ]
    public Sprite[] knockbackFall;      // 1 key frames [ 47 ]
    public Sprite[] knockdown;          // 1 key frames [ 48 ]
    public Sprite[] recover;            // 1 key frames [ 49 ]
    public Sprite[] airRecover;         // 4 key frames [ 50 - 53 ]
    public Sprite[] death;              // 8 key frames [ 54 - 61 ]

    // (u) Unarmed (Orb)
    public Sprite[] u_standGuard;         // 2 key frames [ 0 - 1 ]
    public Sprite[] u_crouchGuard;        // 1 key frames [ 2 ]
    public Sprite[] u_strafe;             // 2 key frames [ 3 - 4 ]
    public Sprite[] u_standGuardHit;      // 1 key frames [ 5 ]
    public Sprite[] u_crouchGuardHit;     // 1 key frames [ 6 ]
    public Sprite[] u_standLight;         // 2 key frames [ 7 - 8 ]
    public Sprite[] u_standMedium;        // 3 key frames [ 9 - 11 ]
    public Sprite[] u_standHeavy;         // 3 key frames [ 12 - 14 ]
    public Sprite[] u_crouchLight;        // 2 key frames [ 15 - 16 ]
    public Sprite[] u_crouchMedium;       // 3 key frames [ 17 - 19 ]
    public Sprite[] u_crouchHeavy;        // 3 key frames [ 20 - 22 ]
    public Sprite[] u_jumpLight;          // 2 key frames [ 23 - 24 ]
    public Sprite[] u_jumpMedium;         // 3 key frames [ 25 - 27 ]
    public Sprite[] u_jumpHeavy;          // 2 key frames [ 28 - 29 ]
    public Sprite[] u_sLowKick;           // 4 key frames [ 30 - 33 ]
    public Sprite[] u_sSnapKick;          // 4 key frames [ 34 - 37 ]
    public Sprite[] u_sVerticalKick;      // 4 key frames [ 38 - 41 ]
    public Sprite[] u_sThrustKick;        // 5 key frames [ 42 - 46 ]
    public Sprite[] u_sHookKick;          // 5 key frames [ 47 - 51 ]
    public Sprite[] u_sLightDragonPunch;  // 6 key frames [ 52 - 57 ]
    public Sprite[] u_sMedDragonPunch;   // 10 key frames [ 58 - 67 ]
    public Sprite[] u_sMedAxeKick;        // 5 key frames [ 68 - 72 ]
    public Sprite[] u_sHeavyAxeKick;      // 8 key frames [ 73 - 80 ]
    public Sprite[] u_sBuzzsawKick;      // 11 key frames [ 81 - 91 ]

    // (m) Magic Book
    // (g) Gun
    // (k) Katana
    // (l) Greatsword
    // (b) Bastard Sword
    // (s) Spear

}
