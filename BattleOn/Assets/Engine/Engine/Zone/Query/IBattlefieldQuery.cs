using System;
using System.Collections.Generic;

namespace BattleOn.Engine
{
    public interface IBattlefieldQuery : IZoneQuery
    {
        IEnumerable<Card> Attackers { get; }
        IEnumerable<Card> Blockers { get; }
        IEnumerable<Card> Creatures { get; }
        IEnumerable<Card> CreaturesThatCanAttack { get; }
        IEnumerable<Card> CreaturesThatCanBlock { get; }
        IEnumerable<Card> Lands { get; }
        IEnumerable<Card> Legends { get; }

        bool HasCreaturesThatCanAttack { get; }
    }
}
