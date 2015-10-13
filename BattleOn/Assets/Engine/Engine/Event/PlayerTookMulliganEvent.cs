namespace BattleOn.Engine
{
    public class PlayerTookMulliganEvent
    {
        public readonly Player Player;

        public PlayerTookMulliganEvent(Player player)
        {
            Player = player;
        }
    }
}
