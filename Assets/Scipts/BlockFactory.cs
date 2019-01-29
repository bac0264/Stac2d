using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFactory : MonoBehaviour
{
    [System.Serializable]
    public class BlockType {
        public Block pingPongBlock;
        public Block staticBlock;
        public Block rigidBlock;
    }
    public BlockType type;
    public Block generateStaticBlock(ref Bounds blockBounds)
    {
        Block staticBlock = InstantiateBlock(type.staticBlock,ref blockBounds);
        return staticBlock;
    }
    public Block generatePingPongBlock(ref Bounds blockBounds, Vector2 start, Vector2 end)
    {
        Block pingPongBlock = InstantiateBlock(type.pingPongBlock,ref blockBounds);
        PingPongProcess sc = pingPongBlock.gameObject.AddComponent(typeof(PingPongProcess)) as PingPongProcess;
        sc._move(start, end);
        return pingPongBlock;
    }
    
    public Block generateRigidBlock(ref Bounds blockBounds)
    {
        Block rigidBlock = InstantiateBlock(type.rigidBlock,ref blockBounds);
        return rigidBlock;
    }
    Block InstantiateBlock(Block blockPrefab, ref Bounds blockBounds)
    {
        Block block = Instantiate(blockPrefab);
        block.setSize(blockBounds.size);
        block.transform.position = blockBounds.center;

        return block;
    }
}
