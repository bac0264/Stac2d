using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Stack))]
public class Player : MonoBehaviour
{
    Stack _stack;
    // Start is called before the first frame update

    private void Start()
    {
        _stack = GetComponent<Stack>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _stack.PlaceBlock();
        }
    }
}
