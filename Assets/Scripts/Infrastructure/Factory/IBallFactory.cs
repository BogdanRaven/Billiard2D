using GameData;
using UnityEngine;

namespace BilliardFactory
{
    public interface IBallFactory
    {
        public void Load();
        public GameObject Create(BallType ballType, Vector3 at, Transform parent = null);
    }
}