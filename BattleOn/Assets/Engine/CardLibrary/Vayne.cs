using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Vayne : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Vayne")
              .ManaCost(1)
              .Type("")
              .Text("")
              .Power(1)
              .Toughness(1);
        }
    }
}
