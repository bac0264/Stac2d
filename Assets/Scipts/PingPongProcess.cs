using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PingPongProcess : MonoBehaviour
{
    // Start is called before the first frame update
    public void _move(Vector2 start, Vector2 end)
    {
        transform.position = start;
        transform.DOMove(end, ConfigTime.loopTime).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }

    public void _stop()
    {
        transform.DOPause();
    }
}
