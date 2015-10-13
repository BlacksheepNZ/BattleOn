using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleOn.Engine
{
    public class SimpleAbilities : GameObject, IStaticAbilities, IAcceptsCardModifier
    {
        private readonly TrackableSet<Ability> _active;
        private readonly TrackableList<SimpleAbility> _all;

        public SimpleAbilities(IEnumerable<Ability> simpleAbilities)
        {
            _all = new TrackableList<SimpleAbility>(
              simpleAbilities.Select(x => new SimpleAbility(x)));

            _active = new TrackableSet<Ability>(simpleAbilities);
        }

        private SimpleAbilities() { }

        public void Accept(ICardModifier modifier)
        {
            modifier.Apply(this);
        }

        public void Initialize(Engine game)
        {
            Game = game;

            _all.Initialize(ChangeTracker);

            foreach (var staticAbility in _all)
            {
                staticAbility.Initialize(ChangeTracker);
            }

            _active.Initialize(ChangeTracker);
        }

        public void Add(Ability ability)
        {
            var simpleAbility = new SimpleAbility(ability);
            simpleAbility.Initialize(ChangeTracker);
            _all.Add(simpleAbility);

            if (!_active.Contains(ability))
                _active.Add(ability);
        }

        public bool Remove(Ability ability)
        {
            var matches = _all
              .Where(x => x.Value == ability)
              .OrderBy(x => x.IsEnabled ? 0 : 1)
              .ToList();

            if (matches.Count == 0)
            {
                return false;
            }

            _all.Remove(matches.First());

            if (matches.Count(x => x.IsEnabled) == 1)
            {
                _active.Remove(ability);
            }
            return true;
        }

        public void Disable()
        {
            foreach (var staticAbility in _all)
            {
                staticAbility.Disable();
            }

            _active.Clear();
        }

        public void Disable(Ability ability)
        {
            var abilities = _all.Where(x => x.Value == ability);

            foreach (var simpleAbility in abilities)
            {
                simpleAbility.Disable();
            }

            _active.Remove(ability);
        }

        public void Enable(Ability ability)
        {
            var abilities = _all.Where(x => x.Value == ability && !x.IsEnabled)
              .ToList();

            foreach (var simpleAbility in abilities)
            {
                simpleAbility.Enable();
            }

            if (abilities.Count > 0 && !_active.Contains(ability))
            {
                _active.Add(ability);
            }
        }

        public void Enable()
        {
            foreach (var staticAbility in _all)
            {
                staticAbility.Enable();

                if (!_active.Contains(staticAbility.Value))
                    _active.Add(staticAbility.Value);
            }
        }

        public bool Has(Ability ability)
        {
            return _active.Contains(ability);
        }

        public bool Null
        {
            get {  return Has(Ability.Null); }
        }

        public bool Heal
        {
            get {  return Has(Ability.Heal);}
        }

        public bool Charge
        {
            get { return Has(Ability.Charge); }
        }

        public bool Shield
        {
            get { return Has(Ability.Shield); }
        }

        public bool LifeSteal
        {
            get { return Has(Ability.LifeSteal); }
        }

        public bool Stacks
        {
            get { return Has(Ability.Stacks); }
        }

        public bool Thorns
        {
            get { return Has(Ability.Thorns); }
        }

        public bool Immunity
        {
            get { return Has(Ability.Immunity); }
        }

        public bool Stealth
        {
            get { return Has(Ability.Stealth); }
        }

        public bool SpellShield
        {
            get { return Has(Ability.SpellShield); }
        }

        public bool Nuke
        {
            get { return Has(Ability.Nuke); }
        }

        public bool GrievousWounds
        {
            get { return Has(Ability.GrievousWounds); }
        }

        public bool Stun
        {
            get { return Has(Ability.Stun); }
        }

        public bool Silence
        {
            get { return Has(Ability.Silence); }
        }

        public bool Bleed
        {
            get { return Has(Ability.Bleed); }
        }

        public bool Empower
        {
            get { return Has(Ability.Empower); }
        }

        public bool ArmorPenetration
        {
            get { return Has(Ability.ArmorPenetration); }
        }

        public bool ArmorShread
        {
            get { return Has(Ability.ArmorShread); }
        }

        public bool Amplify
        {
            get { return Has(Ability.Amplify); }
        }

        public bool Mobility
        {
            get { return Has(Ability.Mobility); }
        }

        public bool DoubleStrike
        {
            get { return Has(Ability.DoubleStrike); }
        }

        public bool KnockBack
        {
            get { return Has(Ability.KnockBack); }
        }

        public bool Swap
        {
            get { return Has(Ability.Swap); }
        }

        public bool Cleave
        {
            get { return Has(Ability.Cleave); }
        }

        public bool Exhaust
        {
            get { return Has(Ability.Exhaust); }
        }

        public bool Repair
        {
            get { return Has(Ability.Repair); }
        }
    }
}
