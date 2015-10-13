using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Heal : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Heal")
              .ManaCost("1")
              .Type("Sorcery")
              .Text("");
        }
    }
}
