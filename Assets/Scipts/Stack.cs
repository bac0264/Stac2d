using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    public BlockFactory factory;

    private void Awake()
    {
        factory.generatePingPongBlock();
        factory.generateStaticBlock();
    }
}
