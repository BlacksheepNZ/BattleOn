namespace BattleOn.Engine
{
    public class LevelChangedEvent
    {
        public readonly Card Card;

        public LevelChangedEvent(Card card)
        {
            Card = card;
        }
    }
}