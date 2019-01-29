using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
public class Stack : MonoBehaviour
{
    public BlockFactory factory;
    Block _movingBlock;
    Block _topBlock;
    UnityEvent m_MyEvent;
    const int SpawnDistanceFromStack = 2;
    float distance = 0;
    private void Awake()
    {
        if(m_MyEvent == null)
        {
            m_MyEvent = new UnityEvent();
        }
        GenerateInitialStack();
        m_MyEvent.AddListener(nextBlock);
    }
    void OnEnable()
    {
        m_MyEvent.Invoke();
    }
    void OnDisable()
    {
        m_MyEvent.RemoveListener(nextBlock);
    }
    public void nextBlock()
    {
        Bounds topBlockBounds = _topBlock.Bounds;
        Bounds movingBounds = ProcessOverlap.CalculateAboveBounds(ref topBlockBounds);
        Vector3 start = spawnOffset() + movingBounds.center;
        Vector3 end = movingBounds.center - spawnOffset(); 
        _movingBlock = factory.generatePingPongBlock(ref movingBounds, start, end);
    }
    void GenerateInitialStack()
    {
        Bounds blockBounds = new Bounds(Vector3.zero, new Vector3(0.42f,0.42f));
        for (int i = 0; i < 5; ++i)
        {
            _topBlock = factory.generateStaticBlock(ref blockBounds);
            blockBounds = ProcessOverlap.CalculateAboveBounds(ref blockBounds);
        }
    }
    public void PlaceBlock()
    {
        Bounds movingBlockBounds = _movingBlock.Bounds;
        Bounds topBlockBounds = _topBlock.Bounds;

        //==========================================

        //==========================================
        _movingBlock.DOKill();
        Destroy(_movingBlock.gameObject);

        // Check to see if the block overlaps with the top of the stack
        if (ProcessOverlap.Overlap(ref movingBlockBounds, ref topBlockBounds))
        {
            // gen staticBlock and gen rigid Block
            _topBlock = factory.generateStaticBlock(ref movingBlockBounds);
        }
        nextBlock();
    }
    Vector3 spawnOffset()
    {
        return Vector3.left * SpawnDistanceFromStack;
    }
}
