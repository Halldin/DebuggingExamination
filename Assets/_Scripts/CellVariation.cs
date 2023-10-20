using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellVariation : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] SpriteRenderer spriteRenderer;

    void Start()
    {
        //Spawn a cell with a random sprite, and add a polygon collider so it fits the sprite.
        int randomIndex = Random.Range(0, sprites.Length - 1);
        spriteRenderer.sprite = sprites[randomIndex];
        gameObject.AddComponent<PolygonCollider2D>();
    }
}
