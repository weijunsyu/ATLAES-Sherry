using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteShadowEffect : MonoBehaviour
{
    [SerializeField] private Vector3 offset = new Vector3();
    [SerializeField] private Vector3 scale = new Vector3();
    [SerializeField] private Material shadowMaterial = null;
    
    private GameObject shadowObject = null;
    private SpriteRenderer parentSpriteRenderer = null;
    private SpriteRenderer shadowSpriteRenderer = null;

    private void Start()
    {
        shadowObject = new GameObject("Shadow");
        shadowObject.transform.parent = transform;

        shadowObject.transform.localPosition = offset;
        shadowObject.transform.localRotation = Quaternion.identity;
        shadowObject.transform.localScale = scale;

        parentSpriteRenderer = GetComponent<SpriteRenderer>();
        shadowSpriteRenderer = shadowObject.AddComponent<SpriteRenderer>();
        shadowSpriteRenderer.sprite = parentSpriteRenderer.sprite;
        shadowSpriteRenderer.material = shadowMaterial;

        shadowSpriteRenderer.sortingLayerName = parentSpriteRenderer.sortingLayerName;
        shadowSpriteRenderer.sortingOrder = parentSpriteRenderer.sortingOrder;
    }

    private void LateUpdate()
    {
        shadowObject.transform.localPosition = offset;
        shadowSpriteRenderer.sprite = parentSpriteRenderer.sprite;
        shadowSpriteRenderer.flipX = parentSpriteRenderer.flipX;
    }
}
