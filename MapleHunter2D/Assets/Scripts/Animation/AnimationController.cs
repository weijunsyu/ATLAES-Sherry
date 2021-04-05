using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimationController : MonoBehaviour
{
    public struct Animation
    {
        public Sprite[] sprites;
        public float[] timings;
        public int runNum; // where 0 is loop indefinetly, 1 is run once, and so forth
    }

    // Config Parameters

    // Cached References
    private SpriteRenderer spriteRenderer = null;
    public AbstractAnimations animationsList;

    //
    [HideInInspector] public Coroutine animate = null;

    // Unity Events:
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Class Functions:
    public Sprite GetSprite()
    {
        return spriteRenderer.sprite;
    }
    public void SetSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
    //Does each
    public void RunCompoundAnimation(ref Coroutine coroutine, params Animation[] animations)
    {
        coroutine = StartCoroutine(CompoundAnimate(animations));
    }
    public void RunAnimation(Sprite[] sprites, float[] timings, ref Coroutine coroutine, bool loop = false, float scale = 1.0f)
    {
        if (loop)
        {
            coroutine = StartCoroutine(AnimateLoop(sprites, timings, scale));
        }
        else
        {
            coroutine = StartCoroutine(AnimateOnce(sprites, timings, scale));
        }
    }
    private IEnumerator CompoundAnimate(params Animation[] animations)
    {
        foreach (Animation animation in animations)
        {
            if (animation.runNum == 0)
            {
                while (true)
                {
                    for (int i = 0; i < animation.sprites.Length; i++)
                    {
                        SetSprite(animation.sprites[i]);
                        yield return new WaitForSeconds(animation.timings[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < animation.runNum; i++)
                {
                    for (int j = 0; j < animation.sprites.Length; j++)
                    {
                        SetSprite(animation.sprites[j]);
                        yield return new WaitForSeconds(animation.timings[j]);
                    }
                }
            }
        }
    }
    private IEnumerator AnimateLoop(Sprite[] sprites, float[] timings, float scale)
    {
        while (true)
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                SetSprite(sprites[i]);
                yield return new WaitForSeconds(timings[i] * scale);
            }
        }
    }
    private IEnumerator AnimateOnce(Sprite[] sprites, float[] timings, float scale)
    {
        int i = 0;
        for (i = 0; i < sprites.Length - 1; i++)
        {
            SetSprite(sprites[i]);
            yield return new WaitForSeconds(timings[i] * scale);
        }
        SetSprite(sprites[i]);
    }
    public void StopAnimation(ref Coroutine coroutine)
    {
        StopCoroutine(coroutine);
    }
}
