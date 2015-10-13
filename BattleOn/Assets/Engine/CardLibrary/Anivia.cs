using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Anivia : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Anivia")
              .ManaCost(1)
              .Type("")
              .Text("")
              .Power(5)
              .Toughness(2);
        }
    }
}
