using System;

namespace BattleOn.Engine
{
    public interface IModifier : IDisposable
    {
        IModifiable Owner { get; }

        void Activate();
        void Initialize(ModifierParameters p, Engine game);
        void AddLifetime(Lifetime lifetime);
    }
}
