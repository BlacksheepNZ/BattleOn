﻿using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Ryze : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Ryze")
              .ManaCost(1)
              .Type("")
              .Text("")
              .Power(1)
              .Toughness(1);
        }
    }
}
