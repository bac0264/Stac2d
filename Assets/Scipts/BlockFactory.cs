using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFactory : MonoBehaviour
{
    [System.Serializable]
    public class BlockType {
        public Block pingPongBlock;
        public Block staticBlock;
    }
    public BlockType type;
    public Block generateStaticBlock()
    {
        Block staticBlock = Instantiate(type.staticBlock);
        return staticBlock;
    }
    public Block generatePingPongBlock()
    {
        Block pingPongBlock = Instantiate(type.pingPongBlock);
        PingPongProcess sc = pingPongBlock.gameObject.AddComponent(typeof(PingPongProcess)) as PingPongProcess;
        sc._move(Vector3.left, Vector3.right);
        //PingPongProcess pingpong = gameObject.AddComponent(typeof(PingPongProcess));
        return pingPongBlock;
    }
}
