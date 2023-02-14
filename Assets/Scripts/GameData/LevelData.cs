using System.Collections.Generic;
using UnityEngine;

namespace GameData
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Create/LevelData")]
    public class LevelData : ScriptableObject
    {
        public Vector2 startMainBallPosition;
        public List<CueBallData> CueBallsData;
    }
}
