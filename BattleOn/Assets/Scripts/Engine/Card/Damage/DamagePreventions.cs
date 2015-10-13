﻿using System;

namespace BattleOn.Engine
{
    [Copyable]
    public class DamagePreventions : IAcceptsGameModifier
    {
        private readonly TrackableList<DamagePrevention> _preventions = new TrackableList<DamagePrevention>();
        public int Count { get { return _preventions.Count; } }

        public void Accept(IGameModifier modifier)
        {
            modifier.Apply(this);
        }

        public void Initialize(INotifyChangeTracker changeTracker)
        {
            _preventions.Initialize(changeTracker);
        }

        public void AddPrevention(DamagePrevention prevention)
        {
            _preventions.Add(prevention);
        }

        public int PreventDamage(PreventDamageParameters preventDamageParameters)
        {
            return Prevent(preventDamageParameters.Amount, (prevention) => prevention.PreventDamage(preventDamageParameters));
        }

        public int PreventLifeloss(int amount, Player player, bool queryOnly = true)
        {
            return Prevent(amount, (prevention) => prevention.PreventLifeloss(amount, player, queryOnly));
        }

        private int Prevent(int amount, Func<DamagePrevention, int> getPreventedDamage)
        {
            var totalPrevented = 0;

            foreach (var prevention in _preventions)
            {
                totalPrevented += getPreventedDamage(prevention);

                if (totalPrevented >= amount)
                    break;
            }

            return totalPrevented > amount ? amount : totalPrevented;
        }

        public void Remove(DamagePrevention preventaion)
        {
            _preventions.Remove(preventaion);
        }
    }
}