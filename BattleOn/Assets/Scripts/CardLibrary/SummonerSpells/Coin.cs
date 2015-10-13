using BattleOn.Engine;
using System.Collections.Generic;

namespace BattleOn.CardLibrary
{
    public class Coin : CardTemplateSource
    {
        public override IEnumerable<CardTemplate> GetCards()
        {
            yield return Card
              .Named("Coin")
              .Type("Coin")
              .Text("Gain 1 Mana");
                //.ManaAbility(p =>
                //{
                //    p.Text("Gain 1 Mana");
                //    p.ManaAmount(Mana.Blue);
                //});
        }
    }
}
