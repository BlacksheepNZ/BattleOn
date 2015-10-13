namespace BattleOn.Engine
{
    public interface IAcceptsGameModifier
    {
        void Accept(IGameModifier modifier);
    }
}
