namespace BattleOn.Engine
{
    public interface IPlayable
    {
        bool WasPriorityPassed { get; }
        void Play();
    }
}
