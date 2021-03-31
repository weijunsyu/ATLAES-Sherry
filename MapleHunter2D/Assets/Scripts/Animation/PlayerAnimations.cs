using UnityEngine;

public class PlayerAnimations : AbstractAnimations
{
    // Basic
    public Sprite[] idle;               // 2 key frames (timed loop)
    public Sprite[] walkForwards;       // 8 key frames (timed loop)
    public Sprite[] walkBackwards;      // 8 key frames (timed loop)
    public Sprite[] run;                // 8 key frames (timed loop)
    public Sprite[] crouch;             // 2 key frames (timed)
    public Sprite[] jump;               // 2 key frames (conditional)
    public Sprite[] fall;               // 1 key frames (singular)
    public Sprite[] dash;               // 6 key frames (timed)
    public Sprite[] slide;              // 2 key frames (timed loop) 
    public Sprite[] slideJump;          // 1 key frames (singular)
    public Sprite[] standHitHigh;       // 1 key frames (singular) 
    public Sprite[] standHit;           // 1 key frames (singular)  
    public Sprite[] jumpHitHigh;        // 1 key frames (singular)    
    public Sprite[] jumpHit;            // 1 key frames (singular)  
    public Sprite[] crouchHitHigh;      // 1 key frames (singular) 
    public Sprite[] crouchHit;          // 1 key frames (singular) 
    public Sprite[] death;         // x key frames (timed)

    // Unarmed
    public Sprite[] u_standGuard;         // 2 key frames (timed loop)    [0-1]
    public Sprite[] u_crouchGuard;        // 1 key frames (singular)      [2]
    public Sprite[] u_strafe;             // 2 key frames (timed loop)    [3-4]
    public Sprite[] u_standGuardHit;      // 1 key frames (singular)      [5]
    public Sprite[] u_crouchGuardHit;     // 1 key frames (singular)      [6]
    public Sprite[] u_standLight;         // 1 key frames (singular)      [7]
    public Sprite[] u_standMedium;        // 1 key frames (singular)      [8]
    public Sprite[] u_standHeavy;         // 3 key frames (timed)         [9-11]
    public Sprite[] u_crouchLight;        // 1 key frames (singular)      [12]
    public Sprite[] u_crouchMedium;       // 1 key frames (singular)      [13]
    public Sprite[] u_jumpLight;          // 1 key frames (singular)      [14]
    public Sprite[] u_jumpMedium;         // 1 key frames (singular)      [15]
    public Sprite[] u_jumpHeavy;          // 2 key frames (timed)         [16-17]
    public Sprite[] u_sLowKick;           // 2 key frames (timed)         [18-19]
    public Sprite[] u_sSnapKick;          // 2 key frames (timed)         [20-21]
    public Sprite[] u_sThrustKick;        // 5 key frames (timed)         [22-26]
    public Sprite[] u_sSpinHookKick;      // 5 key frames (timed)         [27-31]

    // Saber (katana)
    // Claymore (greatsword)
    // Longsword
    // Gun
}
