using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Barrier : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Barrier")
              .ManaCost("1")
              .Type("Sorcery")
              .Text("");
        }
    }
}
