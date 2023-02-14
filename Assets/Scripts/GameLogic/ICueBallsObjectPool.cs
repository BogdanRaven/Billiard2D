using GameData;
using UnityEngine;

namespace GameLogic
{
    public interface ICueBallsObjectPool
    {
        public CueBall Get(BallType ballType, Vector3 at, Transform parent = null);
        public void Release(CueBall cueBall);
        public void AllRelease();
    }
}