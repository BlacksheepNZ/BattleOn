using System;
using System.Collections.Generic;

namespace BattleOn.Engine
{
    public interface IGraveyardQuery : IZoneQuery
    {
        IEnumerable<Card> Creatures { get; }
    }
}
