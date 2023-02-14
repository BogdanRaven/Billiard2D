using System.Collections.Generic;
using System.Linq;
using BilliardFactory;
using GameData;
using UnityEngine;
using Zenject;

namespace GameLogic
{
    public class CueBallsObjectPool : ICueBallsObjectPool
    {
        private List<CueBall> available = new List<CueBall>();
        private List<CueBall> inUse = new List<CueBall>();

        private IBallFactory _ballFactory;

        [Inject]
        public void Context(IBallFactory iBallFactory)
        {
            _ballFactory = iBallFactory;
            _ballFactory.Load();
        }

        public CueBall Get(BallType ballType, Vector3 at, Transform parent = null)
        {
            CueBall cueBall = null;
            if (available.Count(ball => ball.GetData().BallType == ballType) == 0)
            {
                cueBall = _ballFactory.Create(ballType, at, parent).AddComponent<CueBall>();

                cueBall.Initialize(new CueBallData(ballType, Vector2.zero));
            }
            else
            {
                cueBall = available.FirstOrDefault(ball => ball.GetData().BallType == ballType);
                cueBall.transform.position = at;
                cueBall.gameObject.SetActive(true);
                available.Remove(cueBall);
            }

            inUse.Add(cueBall);
            return cueBall;
        }

        public void Release(CueBall cueBall)
        {
            if (inUse.Remove(cueBall) == false)
            {
                return;
            }

            available.Add(cueBall);
            cueBall.gameObject.SetActive(false);
        }

        public void AllRelease()
        {
            List<CueBall> inUseClone = new List<CueBall>();

            foreach (var cueBall in inUse)
            {
                inUseClone.Add(cueBall);
            }

            foreach (var ingredient in inUseClone)
            {
                Release(ingredient);
            }
        }
    }
}