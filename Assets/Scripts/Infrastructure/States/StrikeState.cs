using GameLogic;
using GameMechanics;

namespace Infrastructure
{
    public class StrikeState : IState
    {
        private StateMachine _stateMachine;

        private IInputController _playerInputController;

        private BilliardLineRenderer _billiardLineRenderer;

        private GameContext _gameContext;

        public StrikeState(StateMachine stateMachine, IInputController playerInputController,
            BilliardLineRenderer billiardLineRenderer, GameContext gameContext)
        {
            _stateMachine = stateMachine;

            _playerInputController = playerInputController;
            _billiardLineRenderer = billiardLineRenderer;
            _gameContext = gameContext;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            _playerInputController.DisablePlayerInput();
            _gameContext.BilliardTable.SetEnableCells(true);
            _billiardLineRenderer.SetEnableLines(false);
            _gameContext.MainBall.GetCollider2D().enabled = true;
            _gameContext.MainBall.EnableBilliardCue(false);
        }
    }
}