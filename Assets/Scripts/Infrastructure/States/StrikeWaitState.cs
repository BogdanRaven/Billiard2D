using GameLogic;
using GameMechanics;

namespace Infrastructure
{
    public class StrikeWaitState : IState
    {
        private StateMachine _stateMachine;

        private PlayerInputController _playerInputController;

        private GameContext _gameContext;
        private BilliardLineRenderer _billiardLineRenderer;


        public StrikeWaitState(StateMachine stateMachine,
            PlayerInputController playerInputController,
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
            _playerInputController.EnablePlayerInput();
            _gameContext.BilliardTable.SetEnableCells(false);
            _billiardLineRenderer.SetEnableLines(true);
            _gameContext.MainBall.GetCollider2D().enabled = false;
            _gameContext.MainBall.EnableBilliardCue(true);
            _gameContext.StopMovementAllBalls();
        }
    }
}