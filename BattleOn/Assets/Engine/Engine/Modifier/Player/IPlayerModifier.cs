using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleOn.Engine
{
    public interface IPlayerModifier : IModifier
    {
        //void Apply(LandLimit landLimit);
        //void Apply(ContiniousEffects continiousEffects);
        void Apply(SkipSteps skipSteps);
    }
}
