using GameLogic;
using UnityEngine;

namespace GameData
{
    public class BilliardCell : MonoBehaviour
    {
        [SerializeField] private BilliardTable _billiardTable;

        private void OnCollisionEnter2D(Collision2D col)
        {
            _billiardTable.onBallHit?.Invoke(col.gameObject);
        }
    }
}