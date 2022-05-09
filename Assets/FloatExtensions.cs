using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FloatExtensions
{
    public static float ToPercent(this float value, float maxValue)
    {
        return value / maxValue;
    }
}
