using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Dyrus : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Dyrus")
              .Type("")
              .Text("")
              .Power(0)
              .Toughness(20);
        }
    }
}
