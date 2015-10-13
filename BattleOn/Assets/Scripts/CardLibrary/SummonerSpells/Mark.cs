using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Mark : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Mark")
              .ManaCost("1")
              .Type("Sorcery")
              .Text("");
        }
    }
}
