﻿using System.Collections.Generic;
using System.Linq;

namespace BattleOn.Engine
{
    public class Attacker : GameObject
    {
        private readonly TrackableList<DamageFromSource> _assignedDamage = new TrackableList<DamageFromSource>();
        private readonly TrackableList<Blocker> _blockers = new TrackableList<Blocker>();
        private readonly Card _card;
        private readonly Trackable<bool> _isBlocked = new Trackable<bool>();

        public Attacker(Card card, Engine game)
        {
            Game = game;
            _card = card;

            _blockers.Initialize(ChangeTracker);
            _assignedDamage.Initialize(ChangeTracker);
            _isBlocked.Initialize(ChangeTracker);
        }

        private Attacker() { }

        public IEnumerable<Blocker> Blockers { get { return _blockers; } }
        public int BlockersCount { get { return _blockers.Count; } }
        public IEnumerable<Blocker> BlockersInDamageAssignmentOrder { get { return _blockers.OrderBy(x => x.DamageAssignmentOrder); } }
        public Card Card { get { return _card; } }
        public Player Controller { get { return _card.Controller; } }
        //public bool HasDeathTouch { get { return _card.Has().Deathtouch; } }
        //public bool HasTrample { get { return _card.Has().Trample; } }
        public int LifepointsLeft { get { return _card.Life; } }
        //public bool AssignsDamageAsThoughItWasntBlocked { get { return _card.Has().AssignsDamageAsThoughItWasntBlocked; } }

        public void AddBlocker(Blocker blocker)
        {
            _blockers.Add(blocker);
            _isBlocked.Value = true;
        }

        public void AssignDamage(DamageFromSource damage)
        {
            _assignedDamage.Add(damage);
        }

        public bool CanBeBlockedBy(Card creature)
        {
            return _card.CanBeBlockedBy(creature);
        }

        public void DealAssignedDamage()
        {
            foreach (var damage in _assignedDamage)
            {
                damage.Source.DealDamageTo(damage.Amount, _card, isCombat: true);
            }

            _assignedDamage.Clear();
        }

        public void DistributeDamageToBlockers()
        {
            Enqueue(new AssignCombatDamage(
              _card.Controller,
              this));
        }

        public void DistributeDamageToBlockers(DamageDistribution distribution)
        {
            foreach (var blocker in _blockers)
            {
                var damage = new DamageFromSource(
                  distribution[blocker], source: Card);

                blocker.AssignDamage(damage);
            }

            var defender = Players.GetOpponent(_card.Controller);

            if (_isBlocked == false) //HasTrample || AssignsDamageAsThoughItWasntBlocked || 
            {
                var unassignedDamage = new DamageFromSource(
                  amount: Card.CalculateCombatDamageAmount() - distribution.Total,
                  source: _card);

                defender.AssignDamage(unassignedDamage);
            }
        }

        //public int CalculateDefendingPlayerLifeloss()
        //{
        //    return QuickCombat.CalculateDefendingPlayerLifeloss(_card, _blockers.Select(x => x.Card));
        //}

        public bool HasBlocker(Blocker blocker)
        {
            return _blockers.Contains(blocker);
        }

        public void RemoveBlocker(Blocker blocker)
        {
            _blockers.Remove(blocker);
        }

        public void RemoveFromCombat()
        {
            Publish(new RemovedFromCombatEvent(Card));

            foreach (var blocker in _blockers)
            {
                blocker.RemoveAttacker();
            }
        }

        //public void SetDamageAssignmentOrder(DamageAssignmentOrder damageAssignmentOrder)
        //{
        //    foreach (var blocker in _blockers)
        //    {
        //        blocker.DamageAssignmentOrder = damageAssignmentOrder[blocker];
        //    }
        //}

        public static implicit operator Card(Attacker attacker)
        {
            return attacker != null ? attacker._card : null;
        }

        //public bool CanBeDealtLeathalCombatDamage()
        //{
        //    return QuickCombat.CanAttackerBeDealtLeathalDamage(Card, _blockers.Select(x => x.Card));
        //}

        //public bool CanKillAnyBlocker()
        //{
        //    return QuickCombat.CanAttackerKillAnyBlocker(Card, _blockers.Select(x => x.Card));
        //}
    }
}