using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Faker : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Faker")
              .Type("")
              .Text("")
              .ManaCost(0)
              .Power(0)
              .Toughness(20);
        }
    }
}
