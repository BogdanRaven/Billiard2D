using GameData;
using GameLogic;
using Infrastructure;
using UnityEngine;
using Zenject;

namespace GameMechanics
{
    public class Initializer : MonoBehaviour
    {
        private StateMachine _stateMachine;

        [SerializeField] private LevelData _levelData;

        [SerializeField] private GameContext _gameContext;
        [SerializeField] private MainBall _mainBall;
        [SerializeField] private BilliardTable _billiardTable;
        [SerializeField] private BilliardLineRenderer _billiardLineRenderer;

        private ICueBallsObjectPool _iCueBallsObjectPool;
        private PlayerInputController _playerInputController;

        [Inject]
        private void Context(ICueBallsObjectPool iCueBallsObjectPool, PlayerInputController inputController)
        {
            _iCueBallsObjectPool = iCueBallsObjectPool;
            _playerInputController = inputController;
        }

        private void Start()
        {
            var stateMachine = new StateMachine(_levelData, _iCueBallsObjectPool, _playerInputController, _mainBall,
                _billiardTable, _billiardLineRenderer, _gameContext);
            stateMachine.EnterState<StartState>();
        }
    }
}