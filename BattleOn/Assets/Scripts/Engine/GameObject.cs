using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleOn.Engine
{
    [Copyable]
    public abstract class GameObject
    {
        public bool IsInitialized { get { return Game != null; } }
        protected Engine Game { get; set; }
        protected Players Players { get { return Game.Players; } }
        protected Stack Stack { get { return Game.Stack; } }
        protected Combat Combat { get { return Game.Combat; } }
        protected TurnInfo Turn { get { return Game.Turn; } }
        //protected SearchRunner Ai { get { return Game.Ai; } }
        protected ChangeTracker ChangeTracker { get { return Game.ChangeTracker; } }

        protected IList<int> GetRandomPermutation(int start, int count)
        {
            return Game.Random.GetRandomPermutation(start, count);
        }

        protected int GenerateRandomNumber(int minValue, int maxValue)
        {
            return Game.Random.Next(minValue, maxValue);
        }

        protected int RollADice()
        {
            return Game.Random.RollADice();
        }

        protected void Unsubscribe(object obj = null)
        {
            obj = obj ?? this;
            Game.Unsubscribe(obj);
        }

        protected void Subscribe(object obj = null)
        {
            obj = obj ?? this;
            Game.Subscribe(obj);
        }

        protected void Publish<T>(T message)
        {
            Game.Publish(message);
        }

        protected void Enqueue(Decision decision)
        {
            Game.Enqueue(decision);
        }
    }
}
