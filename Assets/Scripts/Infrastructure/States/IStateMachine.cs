namespace Infrastructure
{
    public interface IStateMachine
    {
        void EnterState<TState>() where TState : IExitableState;
    }
}
