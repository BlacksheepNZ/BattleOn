namespace BattleOn.Engine
{
    public class AssignedDamageDealtEvent
    {
        public readonly Step Step;

        public AssignedDamageDealtEvent(Step step)
        {
            Step = step;
        }
    }
}