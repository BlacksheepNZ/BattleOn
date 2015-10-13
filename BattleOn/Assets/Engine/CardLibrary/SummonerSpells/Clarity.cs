using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Clarity : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Clarity")
              .ManaCost("1")
              .Type("Sorcery")
              .Text("");
        }
    }
}
