﻿namespace BattleOn.Engine
{
    public class SpellPutOnStackEvent : SpellCastEvent
    {
        public SpellPutOnStackEvent(Card card, Targets targets)
            : base(card, targets) { }
    }
}
