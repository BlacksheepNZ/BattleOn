namespace BattleOn.Engine
{
    [Copyable]
    public class DecisionQueue
    {
        private readonly TrackableList<Decision> _queue = new TrackableList<Decision>();

        public int Count { get { return _queue.Count; } }

        public void Initialize(Engine game)
        {
            _queue.Initialize(game.ChangeTracker);
        }

        public Decision Dequeue()
        {
            var next = _queue[0];
            _queue.Remove(next);
            return next;
        }

        public void Enqueue(Decision decision)
        {
            _queue.Add(decision);
        }
    }
}