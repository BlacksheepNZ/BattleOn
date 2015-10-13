namespace BattleOn.Engine
{
    public class IsValidTargetParam
    {
        public readonly Player Controller;
        public readonly Engine Game;
        public readonly Card OwningCard;
        public readonly ITarget Target;
        private readonly object _message;

        public IsValidTargetParam(Player controller, Engine game, Card owningCard, ITarget target,
          object triggerMessage = null)
        {
            Controller = controller;
            Game = game;
            OwningCard = owningCard;
            Target = target;
            _message = triggerMessage;
        }

        public T TriggerMessage<T>()
        {
            return (T)_message;
        }
    }
}