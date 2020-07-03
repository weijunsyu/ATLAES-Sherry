using UnityEngine;

public class CameraLogic : MonoBehaviour
{

    private void Start()
    {   // Adjust the screen size such that no matter what the physical screen size the game size will always be constant
        AdjustCameraAspectRatio(GameConstants.TARGET_SCREEN_WIDTH_BY_RATIO, GameConstants.TARGET_SCREEN_HEIGHT_BY_RATIO);
    }

    //could be moved to something global? and not some object? debatable
    private void AdjustCameraAspectRatio(float targetWidthByRatio, float targetHeightByRatio)
    {
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
}
