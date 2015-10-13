using System;

namespace BattleOn.Engine
{
    [Flags]
    public enum ManaUsage
    {
        None = 0,
        Spells = 1,
        Abilities = 2,
        Any = Spells | Abilities
    }
}