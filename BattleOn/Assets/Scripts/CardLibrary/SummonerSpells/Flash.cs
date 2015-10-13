using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Flash : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Flash")
              .ManaCost("1")
              .Type("Sorcery")
              .Text("");
        }
    }
}
