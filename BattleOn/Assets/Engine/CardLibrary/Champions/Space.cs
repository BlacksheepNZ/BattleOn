using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Space : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Space")
              .Type("")
              .Text("")
              .Power(0)
              .Toughness(20);
        }
    }
}
