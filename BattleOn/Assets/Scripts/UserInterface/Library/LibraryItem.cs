﻿using BattleOn.Engine;

namespace BattleOnGame
{
    public class LibraryItem
    {
        public CardInfo Info { get; set; }
        public Card Card { get; set; }
        public virtual int Count { get; set; }
    }
}
