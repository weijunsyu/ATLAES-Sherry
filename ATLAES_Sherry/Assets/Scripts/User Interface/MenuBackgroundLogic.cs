using UnityEngine;
using UnityEngine.UI;
using System;

public class MenuBackgroundLogic : MonoBehaviour
{
    [SerializeField] private Image sherry;
    [SerializeField] private Image aemilia;

    private void Update()
    {
        MoveImage(sherry, 0.1f);
        MoveImage(aemilia, 0.1f, 0.5f);
    }

    private void MoveImage(Image image, float floatRange, float offset = 0)
    {
        float x = 0;
        float y = (float)Math.Sin(0.6f * Time.time + offset) * floatRange;
        float z = image.transform.position.z;
        image.transform.position = new Vector3(x, y, z);
    }
}
