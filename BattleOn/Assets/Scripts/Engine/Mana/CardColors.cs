using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BattleOn.Engine
{
    public class CardColors : Characteristic<List<CardColor>>, IEnumerable<CardColor>, IAcceptsCardModifier
    {
        private CardColors() { }

        public CardColors(IEnumerable<CardColor> colors) : base(colors.ToList()) { }

        public int Count { get { return Value.Count; } }
        public void Accept(ICardModifier modifier) { modifier.Apply(this); }
        public IEnumerator<CardColor> GetEnumerator() { return Value.GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
}