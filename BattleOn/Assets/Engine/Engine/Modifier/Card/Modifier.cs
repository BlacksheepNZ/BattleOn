﻿using System;
using System.Collections.Generic;

namespace BattleOn.Engine
{
    public delegate IModifier ModifierFactory();
    public delegate ICardModifier CardModifierFactory();
    public delegate IGameModifier GameModifierFactory();
    public delegate IPlayerModifier PlayerModifierFactory();

    [Copyable]
    public abstract class Modifier : GameObject, IModifier, ICopyContributor
    {
        private readonly List<Lifetime> _lifetimes = new List<Lifetime>();
        public bool UntilEndOfTurn;
        public Card SourceCard { get; private set; }
        //public Effect SourceEffect { get; private set; }
        public Card OwningCard { get { return (Card)Owner; } }
        public int? X { get; private set; }

        void ICopyContributor.AfterMemberCopy(object original)
        {
            foreach (var lifetime in _lifetimes)
            {
                lifetime.Ended += RemoveModifier;
            }
        }

        public IModifiable Owner { get; private set; }

        public void Dispose()
        {
            Unapply();

            Unsubscribe(this);
            DisposeLifetimes();
        }

        public virtual void Activate()
        {
            Subscribe(this);

            foreach (var lifetime in _lifetimes)
            {
                lifetime.Ended += RemoveModifier;
                Subscribe(lifetime);
            }
        }

        public void Initialize(ModifierParameters p, Engine game)
        {
            Game = game;
            SourceCard = p.SourceCard;
            //SourceEffect = p.SourceEffect;
            Owner = p.Owner;
            X = p.X;

            InitializeLifetimes(p.IsStatic);
            Initialize();
        }

        public virtual void Apply(CardController controller) { }
        //public virtual void Apply(TriggeredAbilities abilities) { }
        //public virtual void Apply(SimpleAbilities abilities) { }
        //public virtual void Apply(ActivatedAbilities abilities) { }
        //public virtual void Apply(CardColors colors) { }
        //public virtual void Apply(DamagePreventions damagePreventions) { }
        //public virtual void Apply(Protections protections) { }
        public virtual void Apply(CardTypeCharacteristic cardType) { }
        //public virtual void Apply(Counters counters) { }
        //public virtual void Apply(Level level) { }
        //public virtual void Apply(DamageRedirections damageRedirections) { }
        //public virtual void Apply(ContiniousEffects continiousEffects) { }
        //public virtual void Apply(LandLimit landLimit) { }
        //public virtual void Apply(Strenght strenght) { }
        public virtual void Apply(SkipSteps skipSteps) { }
        //public virtual void Apply(CostModifiers costModifiers) { }

        public void AddLifetime(Lifetime lifetime)
        {
            _lifetimes.Add(lifetime);
        }

        protected abstract void Unapply();

        private void DisposeLifetimes()
        {
            foreach (var lifetime in _lifetimes)
            {
                Unsubscribe(lifetime);
                lifetime.Ended -= RemoveModifier;
            }
        }

        private void RemoveModifier(object sender, EventArgs e)
        {
            Remove();
        }

        private void Remove()
        {
            Owner.RemoveModifier(this);
        }

        protected virtual void Initialize() { }

        private void InitializeLifetimes(bool isStatic)
        {
            if (isStatic == false)
            {
                if (Owner is Card)
                {
                    _lifetimes.Add(new OwningCardLifetime());
                }

                if (UntilEndOfTurn)
                {
                    _lifetimes.Add(new EndOfTurnLifetime());
                }

                if (SourceCard.Is().Attachment)
                {
                    _lifetimes.Add(new AttachmentLifetime());
                }
            }

            foreach (var lifetime in _lifetimes)
            {
                lifetime.Initialize(Game, this);
            }
        }
    }
}