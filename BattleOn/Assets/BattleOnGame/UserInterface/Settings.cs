using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace BattleOnGame
{
    public static class Settings
    {
        public static int SCREENWIDTH = 1920;
        public static int SCREENHEIGHT = 1080;

        public static int MAXCARDS = 10;
        public static int MAXDUPLICATES = 3;

        public static Vector2 PREVIEWPOSITION = new Vector2(1380, 400);
        public static Vector2 DECKPOSITION = new Vector2(100, 780);
        public static Vector2 DECKPREVIEWPOSITION = new Vector2(1580, 100);
    }
}
