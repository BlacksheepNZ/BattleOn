﻿using System.Collections.Generic;
using System.Linq;
using BattleOn;
using BattleOn.Engine;

namespace BattleOnGame
{
    public static class DeckLibrary
    {
        private static readonly ResourceFolder Folder = "decks";

        public static IEnumerable<Deck> ReadDecks()
        {
            return Folder.ReadAll().Select(r => DeckFile.Read(r.Name, r.Content));
        }

        public static void Write(Deck deck)
        {
            Folder.WriteFile(deck.Name, DeckFile.Write(deck));
        }
    }
}