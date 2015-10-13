using BattleOn.Engine;

namespace BattleOnGame
{
    public class MatchParameters
    {
        public PlayerParameters Player1 { get; private set; }
        public PlayerParameters Player2 { get; private set; }
        public bool IsTournament { get; private set; }

        public static MatchParameters Default(PlayerParameters player1, PlayerParameters player2, bool isTournament = false)
        {
            return new MatchParameters
            {
                Player1 = player1,
                Player2 = player2,
                IsTournament = isTournament
            };
        }
    }
}