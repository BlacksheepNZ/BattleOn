using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Clairvoyance : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Clairvoyance")
              .ManaCost("1")
              .Type("Sorcery")
              .Text("");
        }
    }
}
