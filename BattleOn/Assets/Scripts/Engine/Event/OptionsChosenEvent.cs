namespace BattleOn.Engine
{
    public class OptionsChosenEvent
    {
        public OptionsChosenEvent(string text)
        {
            Text = text;
        }

        public readonly string Text;
    }
}