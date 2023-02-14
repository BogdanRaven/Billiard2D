using GameData;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace BilliardFactory
{
    public class BallFactory : IBallFactory
    {
        private DiContainer _container;

        private Object whiteBallPrefab;
        private Object blackBallPrefab;
        private Object yellowBallPrefab;
        private Object redBallPrefab;

        public BallFactory(DiContainer container)
        {
            _container = container;
        }

        public void Load()
        {
            whiteBallPrefab = Resources.Load("Balls/WhiteBall");
            blackBallPrefab = Resources.Load("Balls/BlackBall");
            yellowBallPrefab = Resources.Load("Balls/YellowBall");
            redBallPrefab = Resources.Load("Balls/RedBall");
        }

        public GameObject Create(BallType ballType, Vector3 at, Transform parent = null)
        {
            GameObject ball = null;
            switch (ballType)
            {
                case BallType.White:
                    ball = _container.InstantiatePrefab(whiteBallPrefab, at, Quaternion.identity, parent);
                    return ball;
                case BallType.Black:
                    ball = _container.InstantiatePrefab(blackBallPrefab, at, Quaternion.identity, parent);
                    return ball;
                case BallType.Yellow:
                    ball = _container.InstantiatePrefab(yellowBallPrefab, at, Quaternion.identity, parent);
                    return ball;
                case BallType.Red:
                    ball = _container.InstantiatePrefab(redBallPrefab, at, Quaternion.identity, parent);
                    return ball;
            }

            return ball;
        }
    }
}