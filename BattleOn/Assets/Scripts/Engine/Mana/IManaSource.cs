using System.Collections.Generic;

namespace BattleOn.Engine
{
    public interface IManaSource
    {
        bool CanActivate();
        void PayActivationCost();
        Card OwningCard { get; }

        IEnumerable<ManaUnit> GetUnits();
    }
}