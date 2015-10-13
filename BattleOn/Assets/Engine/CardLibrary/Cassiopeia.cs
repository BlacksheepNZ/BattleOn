using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Cassiopeia : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Cassiopeia")
              .ManaCost(1)
              .Type("")
              .Text("")
              .Power(1)
              .Toughness(1);
        }
    }
}
