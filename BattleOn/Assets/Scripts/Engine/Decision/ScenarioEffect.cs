using System;

namespace BattleOn.Engine
{
    public class ScenarioEffect : ITarget, IHasColors
    {
        public Func<Effect> Effect { get; set; }

        public bool HasColor(CardColor color)
        {
            return Effect().HasColor(color);
        }

        public void AddModifier(IModifier modifier) { }

        public void RemoveModifier(IModifier modifier) { }

        public int Id { get { return 0; } }
    }
}
