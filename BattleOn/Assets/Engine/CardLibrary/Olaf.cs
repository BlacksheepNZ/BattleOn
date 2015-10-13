using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Olaf : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Olaf")
              .ManaCost(1)
              .Type("")
              .Text("")
              .Power(1)
              .Toughness(1);
        }
    }
}
