using System;
using UnityEngine;

namespace GameData
{
    [Serializable]
    public class DataBallRelayTuner : MonoBehaviour
    {
        public BallType BallType;
        public Vector2 StartPosition => transform.position;
    }
}