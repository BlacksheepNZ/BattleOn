using System.Collections.Generic;

namespace BattleOn.Engine
{
    public interface IManaAmount : IEnumerable<SingleColorManaAmount>
    {
        int Converted { get; }

        HashSet<int> Colors { get; }
        IManaAmount Add(IManaAmount amount);
        IManaAmount Remove(IManaAmount amount);
    }
}