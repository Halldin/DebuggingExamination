using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellVariation : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] SpriteRenderer spriteRenderer;

    void Start()
    {
        int randomIndex = Random.Range(0, sprites.Length - 1);
        spriteRenderer.sprite = sprites[randomIndex];
        gameObject.AddComponent<PolygonCollider2D>();
    }
}
