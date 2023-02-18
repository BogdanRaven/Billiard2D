using System;
using UnityEngine;

namespace GameData
{
    [Serializable]
    public class CueBallData
    {
        [SerializeField] private BallType _ballType;
        [SerializeField] private Vector2 _startPosition;

        public BallType BallType
        {
            get => _ballType;
            private set => _ballType = value;
        }

        public Vector2 StartPosition
        {
            get => _startPosition;
            private set => _startPosition = value;
        }

        public CueBallData(BallType ballType, Vector2 startPosition)
        {
            BallType = ballType;
            StartPosition = startPosition;
        }
    }
}