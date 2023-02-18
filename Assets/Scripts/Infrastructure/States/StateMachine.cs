using System;
using System.Collections.Generic;
using GameData;
using GameLogic;
using GameMechanics;

namespace Infrastructure
{
    public class StateMachine : IStateMachine
    {
        private Dictionary<Type, IExitableState> States;
        private IExitableState Current { get; set; }

        public StateMachine(LevelData levelData, ICueBallsObjectPool iCueBallsObjectPool,
            IInputController playerInputController, MainBall mainBall, BilliardTable billiardTable,
            BilliardLineRenderer billiardLineRenderer, GameContext gameContext)
        {
            States = new Dictionary<Type, IExitableState>();

            //register
            States[typeof(StartState)] = new StartState(this, levelData, iCueBallsObjectPool, playerInputController,
                mainBall, billiardTable, gameContext);
            States[typeof(StrikeWaitState)] = new StrikeWaitState(this, playerInputController,
                billiardLineRenderer, gameContext);
            States[typeof(StrikeState)] = new StrikeState(this, playerInputController,
                billiardLineRenderer, gameContext);
        }

        public void EnterState<TState>() where TState : IExitableState
        {
            Current?.Exit();
            var state = States[typeof(TState)];
            (state as IState).Enter();
            Current = state;
        }
    }
}