using System.Collections.Generic;
using System.Linq;

namespace BattleOn.Engine
{
    public class PushTriggeredEffects : Decision
    {
        private readonly List<Effect> _effects;

        private PushTriggeredEffects() { }

        public PushTriggeredEffects(Player controller, List<Effect> effects)
            : base(controller, () => new MachineHandler(), () => new MachineHandler())
        {
            _effects = effects;
        }

        private abstract class Handler : DecisionHandler<PushTriggeredEffects, Ordering>
        {
            protected override bool ShouldExecuteQuery
            {
                get { return D._effects.Count > 1; }
            }

            public override void ProcessResults()
            {
                var effects = D._effects
                  .ToList()
                  .ShuffleInPlace(Result.Indices);

                foreach (var effect in effects)
                {
                    Stack.Push(effect);
                }
            }

            protected override void SetResultNoQuery()
            {
                Result = new Ordering(0);
            }
        }

        private class MachineHandler : Handler
        {
            public MachineHandler()
            {
                Result = new Ordering();
            }

            protected override void ExecuteQuery()
            {
                var ordered = D._effects
                  .Select((x, i) => new { Effect = x, Index = i })
                  .OrderBy(x => x.Effect.TriggerOrderRule)
                  .Select(x => x.Index)
                  .ToList();

                var indices = Enumerable.Repeat(0, ordered.Count)
                  .ToArray();

                for (var i = 0; i < ordered.Count; i++)
                {
                    indices[ordered[i]] = i;
                }

                Result = new Ordering(indices);
            }
        }

        //private class PlaybackHandler : Handler
        //{
        //    protected override bool ShouldExecuteQuery
        //    {
        //        get { return true; }
        //    }

        //    public override void SaveDecisionResults() { }

        //    protected override void ExecuteQuery()
        //    {
        //        Result = (Ordering)Game.Recorder.LoadDecisionResult();
        //    }
        //}

        //private class UiHandler : Handler
        //{
        //    protected override void ExecuteQuery()
        //    {
        //        var dialog = Ui.Dialogs.CardOrder.Create(D._effects.Select(x => x.Source), "Set order, lower gets pushed first");
        //        Ui.Shell.ShowModalDialog(dialog, DialogType.Large, InteractionState.Disabled);
        //        Result = new Ordering(dialog.Ordering);
        //    }
        //}
    }
}