using System.Collections.Generic;
using GameData;
using GameLogic;
using GameMechanics;

namespace Infrastructure
{
    public class StartState : IState
    {
        private StateMachine _stateMachine;

        private ICueBallsObjectPool objectPool;
        private LevelData _levelData;
        private PlayerInputController _playerInputController;
        private GameContext _gameContext;

        private MainBall _mainBall;
        private BilliardTable _billiardTable;

        private List<CueBall> _cueBalls;

        public StartState(StateMachine stateMachine, LevelData levelData, ICueBallsObjectPool iCueBallsObjectPool,
            PlayerInputController playerInputController, MainBall mainBall, BilliardTable billiardTable,
            GameContext gameContext)
        {
            _stateMachine = stateMachine;

            _levelData = levelData;
            objectPool = iCueBallsObjectPool;
            _playerInputController = playerInputController;

            _mainBall = mainBall;
            _billiardTable = billiardTable;
            _gameContext = gameContext;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            _playerInputController.EnablePlayerInput();

            InitializeGameBoard();

            _stateMachine.EnterState<StrikeWaitState>();
        }

        private void InitializeGameBoard()
        {
            _cueBalls = new List<CueBall>();
            objectPool.AllRelease();

            _mainBall.StopMovement();
            _mainBall.transform.position = _levelData.startMainBallPosition;

            foreach (var cueBallData in _levelData.CueBallsData)
            {
                var ball = objectPool.Get(cueBallData.BallType, cueBallData.StartPosition);
                _cueBalls.Add(ball);
            }

            _gameContext.Context(_stateMachine, _cueBalls, _mainBall, _billiardTable, objectPool);
        }
    }
}