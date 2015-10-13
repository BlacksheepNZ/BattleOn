using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Arrow : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Arrow")
              .Type("")
              .Text("")
              .Power(0)
              .Toughness(20);
        }
    }
}
