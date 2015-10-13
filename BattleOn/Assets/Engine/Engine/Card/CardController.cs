using System.Linq;

namespace BattleOn.Engine
{
    public class CardController : Characteristic<Player>, IAcceptsCardModifier
    {
        private Card _card;

        private CardController() { }

        public CardController(Player controller) : base(controller) { }

        public void Accept(ICardModifier modifier) { modifier.Apply(this); }

        protected override void OnCharacteristicChanged(Player oldValue, Player newValue)
        {
            if (_card.Zone != Zone.Battlefield)
                return;

            Combat.Remove(_card);

            if (!_card.IsAttached)
            {
                Value.PutCardToBattlefield(_card);

                foreach (var attachment in _card.Attachments.Where(x => x.IsPermanent && (x.Is().Aura || x.Is().Equipment)))
                {
                    // for auras and equipments just change battlefield
                    // do not change the control          
                    Value.PutCardToBattlefield(attachment);
                }
            }

            _card.HasSummoningSickness = true;

            Publish(new ControllerChangedEvent(_card));
        }

        public override void Initialize(Engine game)
        {
            base.Initialize(game);
        }
    }
}