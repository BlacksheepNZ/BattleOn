using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleOn.Engine
{
    public interface IAcceptsCardModifier
    {
        void Accept(ICardModifier modifier);
    }
}
