namespace BattleOn.Engine
{
    public abstract class DamagePrevention : GameObject
    {
        protected Modifier Modifier { get; private set; }

        public virtual void Initialize(Modifier modifier, Engine game)
        {
            Game = game;
            Modifier = modifier;

            Initialize();
        }

        protected virtual void Initialize() { }

        public virtual int PreventDamage(PreventDamageParameters p)
        {
            return 0;
        }

        public virtual int PreventLifeloss(int amount, Player player, bool queryOnly)
        {
            return 0;
        }
    }
}