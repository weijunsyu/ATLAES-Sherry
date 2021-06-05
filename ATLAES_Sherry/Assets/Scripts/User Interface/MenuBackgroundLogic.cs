using UnityEngine;
using UnityEngine.UI;
using System;

public class MenuBackgroundLogic : MonoBehaviour
{
    [SerializeField] private Image sherry;
    [SerializeField] private Image aemilia;
    [SerializeField] private Image redLight;
    [SerializeField] private Image spaceBackground;
    [SerializeField] private Image spaceBackdrop;
    

    private void Update()
    {
        MoveImageY(sherry, 0.1f, 0.6f);
        MoveImageY(aemilia, 0.1f, 0.6f, 0.5f);
        MoveImage(redLight, 0.25f, 0.25f, 1f, 1f);
        MoveImage(spaceBackground, 0.05f, 0.025f, 0.45f, 0.6f);
        MoveImage(spaceBackdrop, 0.05f, 0.05f, 0.25f, 0.25f);
    }
    
    private void MoveImage(Image image, float xRange, float yRange, float xSpeed, float ySpeed)
    {
        MoveImageX(image, xRange, xSpeed);
        MoveImageY(image, yRange, ySpeed);
    }
    private void MoveImageX(Image image, float floatRange, float speed, float offset = 0)
    {
        float y = image.transform.position.y;
        float x = (float)Math.Sin(speed * Time.time + offset) * floatRange;
        float z = image.transform.position.z;
        image.transform.position = new Vector3(x, y, z);
    }
    private void MoveImageY(Image image, float floatRange, float speed, float offset = 0)
    {
        float x = image.transform.position.x;
        float y = (float)Math.Sin(speed * Time.time + offset) * floatRange;
        float z = image.transform.position.z;
        image.transform.position = new Vector3(x, y, z);
    }
    
}
