﻿using System.Collections.Generic;

namespace BattleOn.Engine
{
    public interface IEffectSource
    {
        Card OwningCard { get; }
        Card SourceCard { get; }

        void EffectCountered(SpellCounterReason reason);
        void EffectPushedOnStack();
        void EffectResolved();

        bool IsTargetStillValid(ITarget target, object triggerMessage = null);
        bool ValidateTargetDependencies(List<ITarget> costTargets, List<ITarget> effectTargets);
    }
}
