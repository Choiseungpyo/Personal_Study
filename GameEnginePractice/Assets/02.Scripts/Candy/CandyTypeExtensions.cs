using UnityEngine;

public static class CandyTypeExtensions
{
    public static int ToIndex(this CandyType candyType)
    {
        return (int)candyType;
    }

    public static CandyType ToCandyType(this int index)
    {
        if (index < 0 || index > 2)
        {
            Debug.LogWarning(index);
            return CandyType.Hard;
        }

        return (CandyType)index;
    }
}
