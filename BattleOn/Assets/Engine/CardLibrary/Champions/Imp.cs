using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Imp : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Imp")
              .Type("")
              .Text("")
              .Power(0)
              .Toughness(20);
        }
    }
}
