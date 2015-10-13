using BattleOn;

namespace BattleOn.Engine
{
    public class Level : Characteristic<int?>, IAcceptsCardModifier
    {
        private Card _card;

        private Level() { }
        public Level(int? value) : base(value) { }

        public void Accept(ICardModifier modifier)
        {
            modifier.Apply(this);
        }

        public override void Initialize(Engine game)
        {
            base.Initialize(game);
        }

        protected override void OnCharacteristicChanged(int? oldValue, int? newValue)
        {
            Publish(new LevelChangedEvent(_card));
        }
    }
}