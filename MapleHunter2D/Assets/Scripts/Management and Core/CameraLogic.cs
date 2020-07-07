using UnityEngine;

public class CameraLogic : MonoBehaviour
{

    private Vector2 resolution;
    private bool screenResized;

    private void Start()
    {   // Adjust the screen size such that no matter what the physical screen size the game size will always be constant
        AdjustCameraAspectRatio(GameConstants.TARGET_SCREEN_WIDTH_BY_RATIO, GameConstants.TARGET_SCREEN_HEIGHT_BY_RATIO);
        screenResized = true;
        resolution = new Vector2(Screen.width, Screen.height);
    }
    private void Update()
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
        ResetCamera();
        float targetAspect = targetWidthByRatio / targetHeightByRatio;
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleDifference = windowAspect / targetAspect;
        UnityEngine.Camera.main.aspect = targetAspect;

        if (scaleDifference < 1.0f) //add letterboxes (horizontal lines on the top and bottom)
        {
            float cameraHeight = UnityEngine.Camera.main.orthographicSize * 2;
            float cameraWidth = targetAspect * cameraHeight;
            float offset = ((cameraWidth * Screen.height) - (Screen.width * cameraHeight)) / (Screen.width * 2);
            UnityEngine.Camera.main.aspect = windowAspect;
            UnityEngine.Camera.main.orthographicSize += offset;
        }
        else //add pillarboxes (vertical lines on the left and right)
        {
            UnityEngine.Camera.main.aspect = windowAspect;
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

    private void ResetCamera()
    {
        UnityEngine.Camera.main.orthographicSize = GameConstants.DEFAULT_CAMERA_SIZE;
    }
}
