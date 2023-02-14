using System.Collections.Generic;
using System.Linq;
using GameData;
using Infrastructure;
using UnityEngine;

namespace GameLogic
{
    public class GameContext : MonoBehaviour
    {
        private StateMachine _stateMachine;
        private ICueBallsObjectPool _objectPool;

        private List<CueBall> _cueBalls;
        private MainBall _mainBall;
        private BilliardTable _billiardTable;

        public readonly float timeAnimation = 7f;

        public void Context(StateMachine stateMachine, List<CueBall> cueBalls, MainBall mainBall,
            BilliardTable billiardTable, ICueBallsObjectPool iCueBallsObjectPool)
        {
            _stateMachine = stateMachine;
            _cueBalls = cueBalls;
            _mainBall = mainBall;
            _billiardTable = billiardTable;
            _objectPool = iCueBallsObjectPool;

            _billiardTable.onBallHit += BallHitOnCell;
        }

        public StateMachine StateMachine => _stateMachine;
        public MainBall MainBall => _mainBall;

        public BilliardTable BilliardTable => _billiardTable;
        
        public void EnterStrikeWaitStateAfterDelay(float delay)
        {
            Invoke(nameof(EnterStrikeWaitState), delay);
        }

        public void StopMovementAllBalls()
        {
            _mainBall.StopMovement();
            foreach (var ball in _cueBalls)
            {
                ball.StopMovement();
            }
        }

        public void RestartGame()
        {
            CancelInvoke(nameof(EnterStrikeWaitState));
            _stateMachine.EnterState<StartState>();
        }

        private void OnDestroy()
        {
            _billiardTable.onBallHit -= BallHitOnCell;
        }

        private void EnterStrikeWaitState()
        {
            _stateMachine.EnterState<StrikeWaitState>();
        }

        private void CheckRestartGame()
        {
            if (_cueBalls.Count(ball => ball.isActiveAndEnabled == false) == _cueBalls.Count)
            {
                RestartGame();
            }
        }

        private void BallHitOnCell(GameObject ball)
        {
            if (ball.TryGetComponent<MainBall>(out var mainBall))
            {
                RestartGame();
            }
            else if (ball.TryGetComponent<CueBall>(out var cueBall))
            {
                _objectPool.Release(cueBall);
                CheckRestartGame();
            }
        }
    }
}