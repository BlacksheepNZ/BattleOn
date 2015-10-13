using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleOn.Engine
{
    [Copyable]
    public class DamageFromSource
    {
        public readonly int Amount;
        public readonly Card Source;

        private DamageFromSource() { }

        public DamageFromSource(int amount, Card source)
        {
            Amount = amount;
            Source = source;
        }

        //public bool IsLeathal { get { return Source.Has().Deathtouch; } }
    }
}
