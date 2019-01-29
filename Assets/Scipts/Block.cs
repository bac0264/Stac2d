using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Block : MonoBehaviour
{
    SpriteRenderer _sprite;
    BoxCollider2D _boxCol;
    // Start is called before the first frame update
    public Bounds Bounds { get => _boxCol.bounds; set { _boxCol.offset = value.center; _boxCol.size = value.size; } }
    void Awake()
    {
        _sprite = this.GetComponent<SpriteRenderer>();
        _boxCol = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    public void setSize(Vector2 size)
    {
        _sprite.size = size;
    }
    public void setColor(Color color)
    {
        _sprite.color = color;
    }
}
