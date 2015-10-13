using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Madlife : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Madlife")
              .Type("")
              .Text("")
              .Power(0)
              .Toughness(20);
        }
    }
}
