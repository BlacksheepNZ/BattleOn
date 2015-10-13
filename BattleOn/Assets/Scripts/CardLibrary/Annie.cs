using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Annie : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Annie")
              .ManaCost(1)
              .Type("the dark child")
              .Text("I shudder to think of her capabilitys when she becomes an adult.")
              .Power(2)
              .Toughness(1);
        }
    }
}
