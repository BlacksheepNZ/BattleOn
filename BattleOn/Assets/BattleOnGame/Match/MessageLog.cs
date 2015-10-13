﻿using System.Collections.Generic;
using System.Linq;
using BattleOn;
using BattleOn.Engine;

namespace BattleOnGame
{
    public class MessageLog
    {
        private readonly List<string> _messages = new List<string>();

        public IEnumerable<string> Messages { get { return _messages.AsEnumerable().Reverse(); } }
        public string Last { get { return _messages.Count > 0 ? _messages[_messages.Count - 1] : "No messages"; } }

        [Updates("Last", "Messages")]
        public virtual void AddMessage(string message)
        {
            _messages.Add(message);
        }
    }
}