using System;

namespace BattleOn.Engine
{
    public class StackChangedEventArgs : EventArgs
    {
        public StackChangedEventArgs(Effect effect)
        {
            Effect = effect;
        }

        public Effect Effect { get; private set; }
    }
}
