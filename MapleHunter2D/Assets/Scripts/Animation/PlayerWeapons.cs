using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerWeapons : MonoBehaviour
{
    [Header("Player-Weapons")]
    public Sprite unarmedSprite;
    public Sprite magicSprite;
    public Sprite gunSprite;
    public Sprite katanaSprite;
    public Sprite swordSprite;
    public Sprite greatswordSprite;
    public Sprite daggerSprite;
    public Sprite spearSprite;
    public Sprite naginataSprite;
    public Sprite cubeSprite;

    [Header("Weapon Game Objects")]
    public GameObject primaryWeapon = null;
    public GameObject secondaryWeapon = null;

    private Color white = new Color32(252, 252, 252, 255);
    private Color red = new Color32(208, 0, 0, 255);
    private SpriteRenderer primarySprite = null;
    private SpriteRenderer secondarySprite = null;
    private SpriteRenderer spriteRenderer = null;

    private Vector2 primaryPosOffset;
    private Vector2 secondaryPosOffset;
    
    [HideInInspector] public bool isSliding = false;

    private void Awake()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        primarySprite = primaryWeapon.GetComponent<SpriteRenderer>();
        secondarySprite = secondaryWeapon.GetComponent<SpriteRenderer>();
        primarySprite.color = white;
        secondarySprite.color = red;
    }
    private void Start()
    {
        primaryPosOffset = primaryWeapon.transform.position - transform.position;
        secondaryPosOffset = secondaryWeapon.transform.position - transform.position;
        
        UpdateWeaponSprite();
    }
    private void Update()
    {
        Vector2 primaryOrigin = GetOrigin(primaryPosOffset);
        Vector2 secondaryOrigin = GetOrigin(secondaryPosOffset);

        MoveSprite(primaryWeapon, primaryOrigin, GameConstants.PLAYER_WEAPON_FLOAT_RANGE);
        MoveSprite(secondaryWeapon, secondaryOrigin, GameConstants.PLAYER_WEAPON_FLOAT_RANGE, GameConstants.PLAYER_SECONDARY_FLOAT_OFFSET);
    }
    public void UpdateWeaponSprite()
    {
        SetPrimaryWeaponSprite(MasterManager.playerCharacterPersistentData.GetPrimaryWeapon());
        SetSecondaryWeaponSprite(MasterManager.playerCharacterPersistentData.GetSecondaryWeapon());
    }
    public void SetPrimaryWeaponSprite(WeaponType weapon)
    {
        primarySprite.sprite = DetermineWeaponSprite(weapon);
    }
    public void SetSecondaryWeaponSprite(WeaponType weapon)
    {
        secondarySprite.sprite = DetermineWeaponSprite(weapon);
    }
    private Vector2 GetOrigin(Vector2 offset)
    {
        float x, y;
        if (spriteRenderer.flipX == true)
        {
            if (!isSliding)
            {
                x = transform.position.x - offset.x;
            }
            else
            {
                x = transform.position.x + offset.x;
            }
        }
        else
        {
            if (!isSliding)
            {
                x = transform.position.x + offset.x;
            }
            else
            {
                x = transform.position.x - offset.x;
            }
        }
        y = transform.position.y + offset.y;

        return new Vector2(x, y);
    }
    private void MoveSprite(GameObject weapon, Vector2 origin, float floatRange, float offset = 0f)
    {
        weapon.transform.position = new Vector3(origin.x,
                                                origin.y + ((float)Math.Sin(0.75f * Time.time + offset) * floatRange),
                                                weapon.transform.position.z);
    }

    private Sprite DetermineWeaponSprite(WeaponType weapon)
    {
        switch (weapon)
        {
            case WeaponType.UNARMED:
                return unarmedSprite;
            case WeaponType.MAGIC:
                return magicSprite;
            case WeaponType.GUN:
                return gunSprite;
            case WeaponType.KATANA:
                return katanaSprite;
            case WeaponType.SWORD:
                return swordSprite;
            case WeaponType.GREATSWORD:
                return greatswordSprite;
            case WeaponType.DAGGER:
                return daggerSprite;
            case WeaponType.SPEAR:
                return spearSprite;
            case WeaponType.NAGINATA:
                return naginataSprite;
            case WeaponType.CUBE:
                return cubeSprite;
            default:
                return null;
        }
    }
}
