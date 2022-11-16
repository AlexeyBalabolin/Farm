namespace Infrastructure.GameStates
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
    public interface IPayState<TPayload> : IState
    {
        void Enter(TPayload payload);
    }
}