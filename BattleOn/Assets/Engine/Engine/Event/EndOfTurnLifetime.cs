namespace BattleOn.Engine
{
    public class EndOfTurnEvent { }

    public class EndOfTurnLifetime : Lifetime, IReceive<EndOfTurnEvent>
    {
        public void Receive(EndOfTurnEvent message)
        {
            End();
        }
    }
}
