﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Block : MonoBehaviour
{
    SpriteRenderer _sprite;
    BoxCollider2D _boxCol;
    // Start is called before the first frame update
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
