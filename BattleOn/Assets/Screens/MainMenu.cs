using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Windows;

using Microsoft.Xna.Framework;
using BattleOn.Engine;

namespace BattleOnGame
{
    public class MainMenu : GameScreen
    {
        private const string PlayerName = "You";

        private GameEngine _game;

        public MainMenu(GameEngine game)
        {
            _game = game;
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, false, false);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
