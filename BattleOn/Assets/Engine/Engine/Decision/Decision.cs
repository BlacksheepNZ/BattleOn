using System;

namespace BattleOn.Engine
{
    [Copyable]
    public abstract class Decision
    {
        private readonly Func<IDecisionHandler> _machine;
        private readonly Func<IDecisionHandler> _playback;
        private readonly Func<IDecisionHandler> _scenario;
        private readonly Func<IDecisionHandler> _ui;

        protected Decision()
        {
            /* copyable */
        }

        protected Decision(Player controller, Func<IDecisionHandler> ui,
          Func<IDecisionHandler> scenario) //Func<IDecisionHandler> playback  Func<IDecisionHandler> machine
        {
            _ui = ui;
            //_machine = machine;
            _scenario = scenario;
            //_playback = playback;

            Controller = controller;
        }

        public Player Controller { get; private set; }

        public IDecisionHandler CreateHandler(Engine game)
        {
            var handler = GetHandler(game);
            return handler.Initialize(this, game);
        }

        private IDecisionHandler GetHandler(Engine game)
        {
            //if (game.Ai.IsSearchInProgress)
            //    return _machine();

            //if (game.Recorder.IsPlayback)
            //{
            //    return _playback();
            //}

            switch (Controller.Type)
            {
                case (PlayerType.Human):
                    return _ui();
                case (PlayerType.Scenario):
                    return _scenario();
                default:
                    return _machine();
            }
        }
    }
}