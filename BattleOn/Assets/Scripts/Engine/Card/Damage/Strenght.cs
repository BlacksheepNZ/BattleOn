namespace BattleOn.Engine
{
    [Copyable]
    public class Strenght : IAcceptsCardModifier
    {
        private readonly Characteristic<int?> _power;
        private readonly Trackable<bool> _switchPowerAndToughness = new Trackable<bool>();
        private readonly Characteristic<int?> _toughness;

        private Strenght() { }

        public Strenght(int? power, int? toughness)
        {
            _power = new Characteristic<int?>(power);
            _toughness = new Characteristic<int?>(toughness);
        }

        public int? Power
        {
            get
            {
                var characteristic = _switchPowerAndToughness ? _toughness : _power;
                return characteristic.Value < 0 ? 0 : characteristic.Value;
            }
        }

        public int? Toughness
        {
            get
            {
                var characteristic = _switchPowerAndToughness ? _power : _toughness;
                return characteristic.Value < 0 ? 0 : characteristic.Value;
            }
        }

        public void Accept(ICardModifier modifier)
        {
            modifier.Apply(this);
        }

        public void Initialize(Engine game)
        {
            _power.Initialize(game);
            _toughness.Initialize(game);
            _switchPowerAndToughness.Initialize(game.ChangeTracker);
        }

        public void AddPowerModifier(PropertyModifier<int?> modifier)
        {
            _power.AddModifier(modifier);
        }

        public void AddToughnessModifier(PropertyModifier<int?> modifier)
        {
            _toughness.AddModifier(modifier);
        }

        public void RemovePowerModifier(PropertyModifier<int?> modifier)
        {
            _power.RemoveModifier(modifier);
        }

        public void RemoveToughnessModifier(PropertyModifier<int?> modifier)
        {
            _toughness.RemoveModifier(modifier);
        }

        public void SwitchPowerAndToughness()
        {
            _switchPowerAndToughness.Value = !_switchPowerAndToughness.Value;
        }
    }
}