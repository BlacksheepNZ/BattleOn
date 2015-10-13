﻿using System;
using System.Collections.Generic;

namespace BattleOn.Engine
{
    public abstract class CardTemplateSource
    {
        public CardTemplate Card { get { return new CardTemplate(); } }
        public abstract IEnumerable<CardTemplate> GetCards();

        protected T[] L<T>(params T[] elt)
        {
            return elt;
        }

        //protected DynParam<T> P<T>(Func<Effect, Game, T> getter, EvaluateAt evaluateAt = EvaluateAt.OnInit)
        //{
        //    return new DynParam<T>(getter, evaluateAt);
        //}

        //protected DynParam<T> P<T>(Func<Effect, T> getter, EvaluateAt evaluateAt = EvaluateAt.OnInit)
        //{
        //    return new DynParam<T>((e, g) => getter(e), evaluateAt);
        //}

        //public LevelDefinition Level(int min, int power, int toughness, Static ability, int? max = null)
        //{
        //    return new LevelDefinition
        //    {
        //        Min = min,
        //        Max = max,
        //        Power = power,
        //        Toughness = toughness,
        //        StaticAbility = ability
        //    };
        //}
    }
}