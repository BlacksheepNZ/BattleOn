using System.Linq;

namespace BattleOn.Engine
{
    [Copyable]
    public class DamageRedirections : IAcceptsGameModifier
    {
        private readonly TrackableList<DamageRedirection> _redirections = new TrackableList<DamageRedirection>();

        public void Accept(IGameModifier modifier)
        {
            modifier.Apply(this);
        }

        public void Initialize(ChangeTracker changeTracker)
        {
            _redirections.Initialize(changeTracker);
        }

        public void Add(DamageRedirection prevention)
        {
            _redirections.Add(prevention);
        }

        public bool RedirectDamage(Damage damage, ITarget target)
        {
            foreach (var redirection in _redirections.ToList())
            {
                if (redirection.RedirectDamage(damage, target))
                {
                    return true;
                }
            }

            return false;
        }

        public void Remove(DamageRedirection preventaion)
        {
            _redirections.Remove(preventaion);
        }
    }
}