using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Smite : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Smite")
              .ManaCost("1")
              .Type("Sorcery")
              .Text("");
        }
    }
}
