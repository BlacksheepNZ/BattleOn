using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Wolf : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Wolf")
              .Type("")
              .Text("")
              .Power(0)
              .Toughness(20);
        }
    }
}
