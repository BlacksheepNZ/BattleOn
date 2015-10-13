using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Ghost : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Ghost")
              .ManaCost("1")
              .Type("Sorcery")
              .Text("");
        }
    }
}
