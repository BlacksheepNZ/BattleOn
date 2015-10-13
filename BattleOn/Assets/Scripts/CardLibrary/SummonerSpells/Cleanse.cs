using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Cleance : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Cleanse")
              .ManaCost("1")
              .Type("Sorcery")
              .Text("");
        }
    }
}
