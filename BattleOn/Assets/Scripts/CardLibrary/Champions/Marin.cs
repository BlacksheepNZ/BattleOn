﻿using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Marin : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("MaRin")
              .Type("")
              .Text("")
              .Power(0)
              .Toughness(20);
        }
    }
}
