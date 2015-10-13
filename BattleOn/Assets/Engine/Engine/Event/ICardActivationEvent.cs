namespace BattleOn.Engine
{
    public interface ICardActivationEvent
    {
        Player Controller { get; }
        string GetTitle();
    }
}