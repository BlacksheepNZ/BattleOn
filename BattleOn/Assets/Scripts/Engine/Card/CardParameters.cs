using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BattleOn.Engine
{
    public class CardParameters
    {
        //public readonly List<ActivatedAbility> ActivatedAbilities = new List<ActivatedAbility>();
        //public readonly List<CastRule> CastInstructions = new List<CastRule>();
        //public readonly List<CombatRule> CombatRules = new List<CombatRule>();
        //public readonly List<ContinuousEffect> ContinuousEffects = new List<ContinuousEffect>();
        public readonly List<CardColor> ProtectionsFromColors = new List<CardColor>();
        //public readonly List<string> ProtectionsFromTypes = new List<string>();
        public readonly List<Ability> SimpleAbilities = new List<Ability>();
        //public readonly List<TriggeredAbility> TriggeredAbilities = new List<TriggeredAbility>();
        //public List<StaticAbility> StaticAbilities = new List<StaticAbility>();

        public bool HasXInCost;
        public bool IsLeveler;
        public bool MayChooseToUntap;
        public int MinimalBlockerCount = 1;
        public ScoreOverride OverrideScore = new ScoreOverride();

        public string Name;
        public int? Power;
        public int? Toughness;
        public int? ManaCost;
        public List<CardColor> Colors = new List<CardColor>();
        public List<int> ManaColorsThisCardCanProduce = new List<int>();

        public CardText FlavorText = String.Empty;
        public CardText Text = String.Empty;
        public CardType Type;

        public Vector2 Position;
        public Rectangle Source { get; set; }
        public Color Color { get; set; }
        public float Rotation;
        public float Scale;
        public Texture2D ImageTexture;
        public Texture2D BorderTextures;

        public string Illustration
        {
            get
            {
                const int basicLandVersions = 15;

                if (Type.BasicLand)
                {
                    return Name + RandomEx.Next(1, basicLandVersions + 1);
                }

                return Name;
            }
        }
    }
}