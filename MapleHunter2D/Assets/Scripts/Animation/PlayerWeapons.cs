using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    public Sprite[] weapons;

    public GameObject primaryWeapon = null;
    public GameObject secondaryWeapon = null;

    private Color white = new Color32(252, 252, 252, 255);
    private Color red = new Color32(208, 0, 0, 255);

    private SpriteRenderer primarySprite = null;
    private SpriteRenderer secondarySprite = null;

    private void Awake()
    {
        primarySprite = primaryWeapon.GetComponent<SpriteRenderer>();
        secondarySprite = secondaryWeapon.GetComponent<SpriteRenderer>();
        primarySprite.color = white;
        secondarySprite.color = red;
    }
    private void Start()
    {
        SetPrimaryWeaponSprite(MasterManager.playerCharacterPersistentData.GetPrimaryWeapon());
        SetSecondaryWeaponSprite(MasterManager.playerCharacterPersistentData.GetSecondaryWeapon());
    }

    public void SwapWeaponSprite()
    {
        SetPrimaryWeaponSprite(MasterManager.playerCharacterPersistentData.GetSecondaryWeapon());
        SetSecondaryWeaponSprite(MasterManager.playerCharacterPersistentData.GetPrimaryWeapon());
    }

    public void SetPrimaryWeaponSprite(WeaponType weapon)
    {
        if (weapon == WeaponType.NANOBlADES)
        {
            weapon = WeaponType.NONE;
        }
        primarySprite.sprite = weapons[(int)weapon];
    }
    public void SetSecondaryWeaponSprite(WeaponType weapon)
    {
        if (weapon == WeaponType.NANOBlADES)
        {
            weapon = WeaponType.NONE;
        }
        secondarySprite.sprite = weapons[(int)weapon];
    }
}
