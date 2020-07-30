using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    //[SerializeField] GameObject playerCharacter = null;

    private Camera mainCamera = null; 

    private Vector2 resolution;
    private bool screenResized;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        // Adjust the screen size such that no matter what the physical screen size the game size will always be constant
        AdjustCameraAspectRatio(GameConstants.TARGET_SCREEN_WIDTH_BY_RATIO, GameConstants.TARGET_SCREEN_HEIGHT_BY_RATIO);
        screenResized = true;
        resolution = new Vector2(Screen.width, Screen.height);
    }
    private void Update()
    {
        // Change screen size dynamically as window size changes
        MaintainAspectRatio();
    }

    private void MaintainAspectRatio()
    {
        if (screenSizeChanged())
        {
            screenResized = false;
            resolution = new Vector2(Screen.width, Screen.height);
        }
        else
        {
            if (!screenResized)
            {
                AdjustCameraAspectRatio(GameConstants.TARGET_SCREEN_WIDTH_BY_RATIO, GameConstants.TARGET_SCREEN_HEIGHT_BY_RATIO);
                screenResized = true;
            }
        }
    }

    private void AdjustCameraAspectRatio(float targetWidthByRatio, float targetHeightByRatio)
    {
        float targetAspect = targetWidthByRatio / targetHeightByRatio;
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        if (scaleHeight < 1.0f) //add letterboxes (horizontal lines on the top and bottom)
        {
            Rect rect = mainCamera.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            mainCamera.rect = rect;
        }
        else //add pillarboxes (vertical lines on the left and right)
        {
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = mainCamera.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            mainCamera.rect = rect;
        }
    }
    
    private bool screenSizeChanged()
    {
        if (resolution.x != Screen.width || resolution.y != Screen.height)
        {
            return true;
        }
        return false;
    }
}
