namespace BattleOn
{
    public interface IReceive<in T> : IReceive
    {
        void Receive(T message);
    }

    public interface IReceive { }
}
