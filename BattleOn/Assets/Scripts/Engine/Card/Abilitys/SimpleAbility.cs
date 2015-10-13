namespace BattleOn.Engine
{
    [Copyable]
    public class SimpleAbility
    {
        private readonly Trackable<bool> _isEnabled = new Trackable<bool>(true);
        private readonly Ability _value;

        private SimpleAbility() { }

        public SimpleAbility(Ability value)
        {
            _value = value;
        }

        public Ability Value { get { return _value; } }
        public bool IsEnabled { get { return _isEnabled.Value; } private set { _isEnabled.Value = value; } }

        public SimpleAbility Initialize(INotifyChangeTracker changeTracker)
        {
            _isEnabled.Initialize(changeTracker);

            return this;
        }

        public void Enable()
        {
            IsEnabled = true;
        }

        public void Disable()
        {
            IsEnabled = false;
        }
    }
}