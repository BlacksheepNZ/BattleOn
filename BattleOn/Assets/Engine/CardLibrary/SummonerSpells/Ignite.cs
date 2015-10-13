using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Ignite : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Ignite")
              .ManaCost("1")
              .Type("Sorcery")
              .Text("");
        }
    }
}
