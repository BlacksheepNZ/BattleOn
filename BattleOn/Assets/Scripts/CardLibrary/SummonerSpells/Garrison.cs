using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Garrison : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Garrison")
              .ManaCost("1")
              .Type("Sorcery")
              .Text("");
        }
    }
}
