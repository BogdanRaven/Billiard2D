using System;
using UnityEngine;

namespace GameData
{
    [Serializable]
    public class CueBallData
    {
        public BallType BallType;
        public Vector2 StartPosition;

        public CueBallData(BallType ballType, Vector2 startPosition)
        {
            BallType = ballType;
            StartPosition = startPosition;
        }
    }
}