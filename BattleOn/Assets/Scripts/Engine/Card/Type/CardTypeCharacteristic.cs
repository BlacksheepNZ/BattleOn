namespace BattleOn.Engine
{
    public class CardTypeCharacteristic : Characteristic<CardType>, IAcceptsCardModifier
    {
        private Card _card;
        private CardTypeCharacteristic() { }
        public CardTypeCharacteristic(CardType value) : base(value) { }

        public void Accept(ICardModifier modifier)
        {
            modifier.Apply(this);
        }

        public override void Initialize(Engine game)
        {
            base.Initialize(game);
        }

        protected override void OnCharacteristicChanged(CardType oldValue, CardType newValue)
        {
            Publish(new TypeChangedEvent(_card, oldValue, newValue));
        }
    }
}