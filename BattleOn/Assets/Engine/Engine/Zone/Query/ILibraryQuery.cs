using System;

namespace BattleOn.Engine
{
    public interface ILibraryQuery : IZoneQuery
    {
        event EventHandler Shuffled;
    }
}
