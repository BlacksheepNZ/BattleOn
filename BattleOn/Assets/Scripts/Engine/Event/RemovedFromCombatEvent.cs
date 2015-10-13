namespace BattleOn.Engine
{
    public class RemovedFromCombatEvent
    {
        public readonly Card Card;

        public RemovedFromCombatEvent(Card card)
        {
            Card = card;
        }
    }
}