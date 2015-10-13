namespace BattleOn.Engine
{
    public interface IAcceptsPlayerModifier
    {
        void Accept(IPlayerModifier modifier);
    }
}
