using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingScreenLogic : MonoBehaviour
{

    [SerializeField] private Slider progressBar;
    [SerializeField] private Image loadingImageObject;
    [SerializeField] private Sprite[] sprites;
    private Canvas canvas = null;

    private const int STARTING_SLIDER_VALUE = 38;
    private const int MIN_SLIDER_VALUE = 0;
    private const int MAX_SLIDER_VALUE = 705;
    private const float TIMING = 0.15f;

    private Coroutine animate = null;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;

        progressBar.minValue = MIN_SLIDER_VALUE;
        progressBar.maxValue = MAX_SLIDER_VALUE;
        progressBar.value = STARTING_SLIDER_VALUE;

        canvas.sortingLayerName = "UI";
        canvas.sortingOrder = 100;
    }

    private void OnEnable()
    {
        RunAnimation();
    }

    private void OnDisable()
    {
        StopAnimation();
    }


    private void RunAnimation()
    {
        animate = StartCoroutine(AnimateRoutine(sprites));
    }
    private void StopAnimation()
    {
        if (animate != null)
        {
            StopCoroutine(animate);
        }
    }
    private IEnumerator AnimateRoutine(Sprite[] sprites)
    {
        while (true)
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                SetSprite(sprites[i]);
                yield return new WaitForSeconds(TIMING);
            }
        }
    }
    private void SetSprite(Sprite sprite)
    {
        loadingImageObject.sprite = sprite;
    }
}
