using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Teleport : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Teleport")
              .ManaCost("1")
              .Type("Sorcery")
              .Text("");
        }
    }
}
