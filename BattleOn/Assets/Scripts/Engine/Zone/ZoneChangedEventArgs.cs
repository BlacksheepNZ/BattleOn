﻿using System;

namespace BattleOn.Engine
{
    public class ZoneChangedEventArgs : EventArgs
    {
        public Card Card { get; private set; }

        public ZoneChangedEventArgs(Card card)
        {
            Card = card;
        }
    }
}
