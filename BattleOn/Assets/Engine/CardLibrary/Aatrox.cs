using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Aatrox : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Aatrox")
              .ManaCost(1)
              .Type("Fighter")
              .Text("Charge")
              .Power(1)
              .Toughness(3);
        }
    }
}
