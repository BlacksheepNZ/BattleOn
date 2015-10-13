using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Ahri : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Ahri")
              .ManaCost(2)
              .Type("")
              .Text("")
              .Power(1)
              .Toughness(1);
        }
    }
}
