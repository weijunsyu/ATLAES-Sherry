using UnityEngine;

public class PlayerBasicAnimations : AbstractAnimations
{
    public Sprite[] idle;               // 2 key frames (timed loop)    [0-1]
    public Sprite[] walk;               // 8 key frames (timed loop)    [2-9]
    public Sprite[] run;                // 8 key frames (timed loop)    [10-17]
    public Sprite[] crouch;             // 2 key frames (timed)         [18-19]
    public Sprite[] jump;               // 2 key frames (conditional)   [20-21]
    public Sprite[] fall;               // 1 key frames (singular)      [22]
    public Sprite[] dash;               // 7 key frames (timed)         [23-29]
    public Sprite[] slide;              // 2 key frames (timed loop)    [30-31]
    public Sprite[] slideJump;          // 1 key frames (singular)      [32]
    public Sprite[] standHitHigh;       // 1 key frames (singular)      [33]
    public Sprite[] standHit;           // 1 key frames (singular)      [34]
    public Sprite[] jumpHitHigh;        // 1 key frames (singular)      [35]
    public Sprite[] jumpHit;            // 1 key frames (singular)      [36]
    public Sprite[] crouchHitHigh;      // 1 key frames (singular)      [37]
    public Sprite[] crouchHit;          // 1 key frames (singular)      [38]
    public Sprite[] standDeath;         // x key frames (x)             [x-x] (39-46)
    public Sprite[] crouchDeath;        // x key frames (x)             [x-x]
    public Sprite[] airDeath;           // x key frames (x)             [x-x]
}
