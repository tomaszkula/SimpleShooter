using System;

[Serializable]
public struct TSG_MinMax
{
    public float Min;
    public float Max;

    public float Random => UnityEngine.Random.Range(Min, Max);

    public TSG_MinMax(float _min, float _max)
    {
        Min = _min;
        Max = _max;
    }
}
