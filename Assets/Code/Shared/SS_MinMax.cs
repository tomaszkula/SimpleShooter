using System;

[Serializable]
public struct SS_MinMax
{
    public float Min;
    public float Max;

    public float Random => UnityEngine.Random.Range(Min, Max);

    public SS_MinMax(float _min, float _max)
    {
        Min = _min;
        Max = _max;
    }

    public bool IsInRange(float _value)
    {
        return Min <= _value && Max >= _value;
    }
}
