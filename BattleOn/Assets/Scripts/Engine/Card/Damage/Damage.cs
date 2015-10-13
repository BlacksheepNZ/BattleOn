﻿namespace BattleOn.Engine
{
    [Copyable]
    public class Damage
    {
        private readonly Trackable<int> _amount;
        private readonly TrackableList<DamageRedirection> _redirections = new TrackableList<DamageRedirection>();

        public Damage(int amount, bool isCombat, Card source)
        {
            _amount = new Trackable<int>(amount);
            IsCombat = isCombat;
            Source = source;
        }

        private Damage() { }

        public int Amount { get { return _amount.Value; } set { _amount.Value = value; } }
        public bool IsCombat { get; private set; }
        public Card Source { get; private set; }

        //public bool IsLeathal { get { return Source.Has().Deathtouch; } }

        public void Initialize(ChangeTracker changeTracker)
        {
            _amount.Initialize(changeTracker);
            _redirections.Initialize(changeTracker);
        }

        public bool WasAlreadyRedirected(DamageRedirection damageRedirection)
        {
            return _redirections.Contains(damageRedirection);
        }

        public void AddRedirection(DamageRedirection damageRedirection)
        {
            _redirections.Add(damageRedirection);
        }
    }
}