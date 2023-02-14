using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class BilliardTable : MonoBehaviour
    {
        [SerializeField] private List<GameObject> cells;

        public Action<GameObject> onBallHit;

        public void SetEnableCells(bool enable)
        {
            foreach (var cell in cells)
            {
                cell.gameObject.SetActive(enable);
            }
        }
    }
}