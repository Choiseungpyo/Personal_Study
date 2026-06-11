using System;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    public event Action<CandyType, int> OnCandyCountChanged;

    private Dictionary<CandyType, int> candy = new Dictionary<CandyType, int>()
    {
        { CandyType.Hard, 0 },
        { CandyType.Lollipop, 0 },
        { CandyType.Muffin, 0 }
    };

    private void Start()
    {
        ResetCandyCnt();
        NotifyAllCandyCountsChanged();
    }

    public void ChangeCandyCnt(CandyType type, int candyCnt)
    {
        candy[type] += candyCnt;

        if (candy[type] < 0)
            candy[type] = 0;

        OnCandyCountChanged?.Invoke(type, candy[type]);
    }

    public int ReturnCandyCnt(CandyType type)
    {
        return candy[type];
    }

    public CandyType ReturnRandomCandy()
    {
        int randCandyType = UnityEngine.Random.Range(0, candy.Count);
        return (CandyType)randCandyType;
    }

    public bool TryReturnRandomOwnedCandy(out CandyType candyType)
    {
        List<CandyType> availableCandys = new List<CandyType>();

        foreach (KeyValuePair<CandyType, int> pair in candy)
        {
            if (pair.Value > 0)
                availableCandys.Add(pair.Key);
        }

        if (availableCandys.Count <= 0)
        {
            candyType = CandyType.Hard;
            return false;
        }

        int randCandyType = UnityEngine.Random.Range(0, availableCandys.Count);
        candyType = availableCandys[randCandyType];
        return true;
    }

    public void NotifyAllCandyCountsChanged()
    {
        foreach (KeyValuePair<CandyType, int> pair in candy)
            OnCandyCountChanged?.Invoke(pair.Key, pair.Value);
    }

    private void ResetCandyCnt()
    {
        candy[CandyType.Hard] = 0;
        candy[CandyType.Lollipop] = 0;
        candy[CandyType.Muffin] = 0;
    }
}