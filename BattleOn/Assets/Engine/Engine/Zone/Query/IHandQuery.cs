using System.Collections.Generic;

namespace BattleOn.Engine
{
    public interface IHandQuery : IZoneQuery
    {
        IEnumerable<Card> Lands { get; }
    }
}
