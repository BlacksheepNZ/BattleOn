namespace BattleOn.Engine
{
    [Copyable]
    public abstract class DamageRedirection : GameObject
    {
        public Modifier Modifier { get; private set; }

        public bool RedirectDamage(Damage damage, ITarget target)
        {
            if (damage.WasAlreadyRedirected(this))
                return false;

            var wasRedirected = Redirect(damage, target);

            if (wasRedirected)
                damage.AddRedirection(this);

            return wasRedirected;
        }

        public virtual void Initialize(Modifier modifier, Engine game)
        {
            Modifier = modifier;
            Game = game;
        }

        protected abstract bool Redirect(Damage damage, ITarget target);
    }
}