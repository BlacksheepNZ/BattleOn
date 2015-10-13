using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Exhaust : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Exhaust")
              .ManaCost("1")
              .Type("Sorcery")
              .Text("");
        }
    }
}
