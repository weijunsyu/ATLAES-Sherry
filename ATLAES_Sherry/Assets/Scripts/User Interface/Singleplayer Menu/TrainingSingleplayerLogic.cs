using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TrainingSingleplayerLogic : MonoBehaviour
{
    [SerializeField] private SceneLoaderRef sceneLoader = null;
    [SerializeField] private TrainingSingleplayerData tsData = null;
    [SerializeField] private Image alphaMask = null;

    [Header("Left Character Select")]
    [SerializeField] private Toggle leftCharacterToggle = null;
    [SerializeField] private Image leftCharacterImage = null;
    [SerializeField] private Image leftCharacterStaticImage = null;
    [SerializeField] private Button leftPrimaryButton = null;
    [SerializeField] private Image leftPrimaryImage = null;
    [SerializeField] private Button leftSecondaryButton = null;
    [SerializeField] private Image leftSecondaryImage = null;
    [Header("Right Character Select")]
    [SerializeField] private Toggle rightCharacterToggle = null;
    [SerializeField] private Image rightCharacterImage = null;
    [SerializeField] private Image rightCharacterStaticImage = null;
    [SerializeField] private Button rightPrimaryButton = null;
    [SerializeField] private Image rightPrimaryImage = null;
    [SerializeField] private Button rightSecondaryButton = null;
    [SerializeField] private Image rightSecondaryImage = null;
    [Header("Weapon Select")]
    [SerializeField] private Canvas weaponSelectCanvas = null;
    [SerializeField] private Button unarmedWeaponButton = null;
    [SerializeField] private Button magicWeaponButton = null;
    [SerializeField] private Button gunWeaponButton = null;
    [SerializeField] private Button katanaWeaponButton = null;
    [SerializeField] private Button swordWeaponButton = null;
    [SerializeField] private Button greatswordWeaponButton = null;
    [SerializeField] private Button daggerWeaponButton = null;
    [SerializeField] private Button spearWeaponButton = null;
    [SerializeField] private Button naginataWeaponButton = null;
    [Header("Sprites")]
    [SerializeField] private Sprite[] characterSprites = null;
    [SerializeField] private Sprite unarmedSprite = null;
    [SerializeField] private Sprite magicSprite = null;
    [SerializeField] private Sprite gunSprite = null;
    [SerializeField] private Sprite katanaSprite = null;
    [SerializeField] private Sprite swordSprite = null;
    [SerializeField] private Sprite greatswordSprite = null;
    [SerializeField] private Sprite daggerSprite = null;
    [SerializeField] private Sprite spearSprite = null;
    [SerializeField] private Sprite naginataSprite = null;

    private Coroutine animate = null;

    private void OnEnable()
    {
        ResetData();
        InitMenu();
    }

    private void RunAnimation()
    {
        StopAnimation();

        if (tsData.isLeftPlayer)
        {
            animate = StartCoroutine(AnimateRoutine(characterSprites, leftCharacterImage));
        }
        else
        {
            animate = StartCoroutine(AnimateRoutine(characterSprites, rightCharacterImage));
        }
        
    }
    private void StopAnimation()
    {
        if (animate != null)
        {
            StopCoroutine(animate);
        }
    }
    private IEnumerator AnimateRoutine(Sprite[] sprites, Image image)
    {
        while (true)
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                SetSprite(sprites[i], image);
                yield return new WaitForSeconds(PlayerTimings.IDLE_TIMES[i]);
            }
        }
    }
    private void SetSprite(Sprite sprite, Image image)
    {
        image.sprite = sprite;
    }
    public void StartTraining()
    {
        sceneLoader.AsyncLoadSceneByIndex(tsData.stageSceneIndex);
    }
    public void SelectLeftPlayer(bool isLeft)
    {
        tsData.isLeftPlayer = isLeft;
        SetWeaponColor();
        ToggleCharacterStaticImage();
        RunAnimation();
    }
    public void SelectRightPlayer(bool isRight)
    {
        tsData.isLeftPlayer = !isRight;
        SetWeaponColor();
        ToggleCharacterStaticImage();
        RunAnimation();
    }

    public void SelectWeaponButton(int weaponSlot)
    {
        tsData.tempWeaponSelector = weaponSlot;
        alphaMask.enabled = true;
        weaponSelectCanvas.enabled = true;
        DisableInvalidWeapons(weaponSlot);
    }
    public void SelectWeaponFinal(int weaponType)
    {
        WeaponType weapon = (WeaponType)weaponType;
        alphaMask.enabled = false;
        weaponSelectCanvas.enabled = false;

        switch (tsData.tempWeaponSelector)
        {
            case TrainingSingleplayerData.LEFT_PRIMARY:
                tsData.leftPrimary = weapon;
                leftPrimaryImage.sprite = GetWeaponSprite(weapon);
                break;
            case TrainingSingleplayerData.LEFT_SECONDARY:
                tsData.leftSecondary = weapon;
                leftSecondaryImage.sprite = GetWeaponSprite(weapon);
                break;
            case TrainingSingleplayerData.RIGHT_PRIMARY:
                tsData.rightPrimary = weapon;
                rightPrimaryImage.sprite = GetWeaponSprite(weapon);
                break;
            case TrainingSingleplayerData.RIGHT_SECONDARY:
                tsData.rightSecondary = weapon;
                rightSecondaryImage.sprite = GetWeaponSprite(weapon);
                break;
        }
    }

    public void ToggleOnStage(int stageIndex)
    {
        tsData.stageSceneIndex = stageIndex;
    }

    private void ResetData()
    {
        tsData.isLeftPlayer = true;
        tsData.leftPrimary = WeaponType.KATANA;
        tsData.leftSecondary = WeaponType.GUN;
        tsData.rightPrimary = WeaponType.KATANA;
        tsData.rightSecondary = WeaponType.GUN;
        tsData.stageSceneIndex = TrainingSingleplayerData.CLASSIC_INDEX;
    }
    private void InitMenu()
    {
        leftCharacterToggle.isOn = tsData.isLeftPlayer;
        leftPrimaryImage.sprite = GetWeaponSprite(tsData.leftPrimary);
        leftSecondaryImage.sprite = GetWeaponSprite(tsData.leftSecondary);
        rightPrimaryImage.sprite = GetWeaponSprite(tsData.rightPrimary);
        rightSecondaryImage.sprite = GetWeaponSprite(tsData.rightSecondary);

        SetWeaponColor();
        ToggleCharacterStaticImage();
        RunAnimation();
    }
    private void ToggleCharacterStaticImage()
    {
        if (tsData.isLeftPlayer)
        {
            leftCharacterStaticImage.enabled = false;
            rightCharacterStaticImage.enabled = true;
        }
        else
        {
            rightCharacterStaticImage.enabled = false;
            leftCharacterStaticImage.enabled = true;
        }
    }
    private void EnableAllWeapons()
    {
        unarmedWeaponButton.interactable = true;
        magicWeaponButton.interactable = true;
        gunWeaponButton.interactable = true;
        katanaWeaponButton.interactable = true;
        swordWeaponButton.interactable = true;
        greatswordWeaponButton.interactable = true;
        daggerWeaponButton.interactable = true;
        spearWeaponButton.interactable = true;
        naginataWeaponButton.interactable = true;
    }
    private void DisableWeapon(Button disabledWeapon)
    {
        disabledWeapon.interactable = false;
    }
    private void DisableInvalidWeapons(int weaponSlot)
    {
        EnableAllWeapons();
        switch (weaponSlot)
        {
            case TrainingSingleplayerData.LEFT_PRIMARY:
                DisableWeapon(GetWeaponButton(tsData.leftPrimary));
                DisableWeapon(GetWeaponButton(tsData.leftSecondary));
                break;
            case TrainingSingleplayerData.LEFT_SECONDARY:
                DisableWeapon(GetWeaponButton(tsData.leftSecondary));
                DisableWeapon(GetWeaponButton(tsData.leftPrimary));
                break;
            case TrainingSingleplayerData.RIGHT_PRIMARY:
                DisableWeapon(GetWeaponButton(tsData.rightPrimary));
                DisableWeapon(GetWeaponButton(tsData.rightSecondary));
                break;
            case TrainingSingleplayerData.RIGHT_SECONDARY:
                DisableWeapon(GetWeaponButton(tsData.rightSecondary));
                DisableWeapon(GetWeaponButton(tsData.rightSecondary));
                break;
        }
    }
    private void SetWeaponColor()
    {
        if (tsData.isLeftPlayer)
        {
            leftPrimaryImage.color = GameConstants.TRUE_WHITE;
            leftSecondaryImage.color = GameConstants.TRUE_WHITE;
            rightPrimaryImage.color = GameConstants.DARK_GREY;
            rightSecondaryImage.color = GameConstants.DARK_GREY;
        }
        else
        {
            leftPrimaryImage.color = GameConstants.DARK_GREY;
            leftSecondaryImage.color = GameConstants.DARK_GREY;
            rightPrimaryImage.color = GameConstants.TRUE_WHITE;
            rightSecondaryImage.color = GameConstants.TRUE_WHITE;
        }
    }
    private Sprite GetWeaponSprite(WeaponType weapon)
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
            default:
                return null;
        }
    }
    private Button GetWeaponButton(WeaponType weapon)
    {
        switch (weapon)
        {
            case WeaponType.UNARMED:
                return unarmedWeaponButton;
            case WeaponType.MAGIC:
                return magicWeaponButton;
            case WeaponType.GUN:
                return gunWeaponButton;
            case WeaponType.KATANA:
                return katanaWeaponButton;
            case WeaponType.SWORD:
                return swordWeaponButton;
            case WeaponType.GREATSWORD:
                return greatswordWeaponButton;
            case WeaponType.DAGGER:
                return daggerWeaponButton;
            case WeaponType.SPEAR:
                return spearWeaponButton;
            case WeaponType.NAGINATA:
                return naginataWeaponButton;
            default:
                return null;
        }
    }
}
