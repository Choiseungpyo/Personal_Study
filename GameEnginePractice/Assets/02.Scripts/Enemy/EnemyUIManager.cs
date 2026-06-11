using UnityEngine;
using UnityEngine.UI;

public class EnemyUIManager : MonoBehaviour
{
    [SerializeField] private Image CandyImg;
    [SerializeField] private Sprite[] CandySprite = new Sprite[3];

    private void OnEnable()
    {
        Refresh();
    }

    public void Refresh()
    {
        EnemyBase enemy = GetComponent<EnemyBase>();
        if (enemy == null)
            return;

        CandyType candyType = enemy.ReturnCandyTypeToTake();

        CandyImg.sprite = CandySprite[candyType.ToIndex()];
    }
}
