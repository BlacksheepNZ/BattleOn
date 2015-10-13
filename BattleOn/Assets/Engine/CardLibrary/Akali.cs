using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Akali : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Akali")
              .ManaCost(2)
              .Type("")
              .Text("")
              .Power(2)
              .Toughness(2);
        }
    }
}
