using System;
using System.Collections.Generic;

namespace BattleOn.Engine
{
    public interface IZoneQuery : IEnumerable<Card>
    {
        int Count { get; }
        event EventHandler<ZoneChangedEventArgs> CardAdded;
        event EventHandler<ZoneChangedEventArgs> CardRemoved;
    }
}
