using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessOverlap : MonoBehaviour
{
    public static bool Overlap(ref Bounds above, ref Bounds low, float ySkin = 0.05f)
    {
        Bounds aboveExpanded = above;
        if (ySkin > 0)
        {
            aboveExpanded.Expand(new Vector3(0, ySkin * aboveExpanded.size.y * ySkin));
        }
        Debug.Log("above.Intersects(low): " + above.Intersects(low));
        return above.Intersects(low);
    }
    public static bool PerfectOverlap(ref Bounds above, ref Bounds low, float errorMargin)
    {
        float x = Mathf.Abs(above.max.x - low.max.x);
        return true;
    }
    public static Bounds CalculateAboveBounds(ref Bounds below)
    {
        Bounds above = below;
        above.center += Vector3.up * below.size.y;
        return above;
    }
}
