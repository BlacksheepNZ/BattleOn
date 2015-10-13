using System;
using System.Linq;
using System.Threading;
using BattleOn;
using BattleOn.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BattleOnGame
{
    public class CardViewModel : ViewModelBase, ICloneable
    {
        public CardViewModel(Card card)
        {
            Card = card;
            Colors = new CardColor[] { };
        }

        public Card Card { get; private set; }

        public string Name { get { return Card.Name; } }
        //public bool HasXInCost { get { return Card.HasXInCost; } }
        public int? ManaCost { get { return Card.ManaCost; } }
        public string Illustration { get { return Card.Illustration; } }
        public CardText Text { get { return Card.Text; } }
        public CardText FlavorText { get { return Card.FlavorText; } }
        public int CharacterCount { get { return Card.CharacterCount; } }
        public virtual int? Power { get; protected set; }
        public virtual int? Toughness { get; protected set; }
        public virtual bool IsVisibleInUi { get; protected set; }
        public virtual CardColor[] Colors { get; protected set; }
        public virtual int Counters { get; protected set; }
        public virtual int? Level { get; protected set; }
        public virtual string Type { get; protected set; }
        public virtual int Damage { get; protected set; }
        public virtual bool IsTapped { get; protected set; }
        public virtual bool HasSummoningSickness { get; protected set; }
        public string Set { get { return Card.Set; } }
        public Rarity? Rarity { get { return Card.Rarity; } }

        private SpriteFont font;

        public bool isVisible = true;
        public bool onHover = false;
        Texture2D hoverTexture;

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// Need to load all card images first.
        /// TextureContent.MissingImage = content.Load<Texture2D>("cards//missing.png");
        /// TextureContent.GetAllCardImages(content, "cards");
        /// </summary>
        public void LoadContent(ContentManager content)
        {
            Card.Position = Vector2.Zero;
            Card.Color = Color.White;
            Card.Rotation = 0.0f;
            Card.Scale = 1.0f;

            Card.ImageTexture = TextureContent.GetCardImage(Card.Name);

            Card.borderPreview = content.Load<Texture2D>("Cards//Border");
            Card.attackPreview = content.Load<Texture2D>("Cards//Attack");
            Card.toughnessPreview = content.Load<Texture2D>("Cards//Toughness");
            Card.costPreview = content.Load<Texture2D>("Cards//Cost");

            hoverTexture = content.Load<Texture2D>("Cards//Hover"); 

            font = content.Load<SpriteFont>("Impact");
        }

        int mAlphaValue = 255;
        int mFadeIncrement = 50;
        double mFadeDelay = .055;

        public void Show()
        {
            isVisible = true;
        }

        public void Hide()
        {
            isVisible = false;
        }

        public void Update(GameTime gameTime, bool fadeIn, bool fadeOut)
        {
            //Update();

            if (isVisible == false)
            {
                if (fadeIn == true)
                {
                    if (mAlphaValue <= 0)
                        return;

                    //If the Fade delays has dropped below zero, then it is time to 
                    //fade in/fade out the image a little bit more.
                    if (mFadeDelay <= 0)
                    {
                        //Reset the Fade delay
                        mFadeDelay = .035;

                        //Increment/Decrement the fade value for the image
                        mAlphaValue -= mFadeIncrement;
                    }
                    else
                    {
                        mFadeDelay -= gameTime.ElapsedGameTime.TotalSeconds;
                    }
                }
                else
                {
                    mAlphaValue = 0;
                }
            }

            if (isVisible == true)
            {
                if (fadeOut == true)
                {
                    if (mAlphaValue >= 255)
                        return;

                    if (mFadeDelay <= 0)
                    {
                        //Reset the Fade delay
                        mFadeDelay = .035;

                        //Increment/Decrement the fade value for the image
                        mAlphaValue += mFadeIncrement;
                    }
                    else
                    {
                        mFadeDelay -= gameTime.ElapsedGameTime.TotalSeconds;
                    }
                }
                else
                {
                    mAlphaValue = 255;
                }
            }

            mAlphaValue = MathHelper.Clamp(mAlphaValue, 0, 255);
        }

        public void DrawCard(SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            Color color = new Color((byte)255, (byte)255, (byte)255, mAlphaValue);

            if (onHover)
            {
                spriteBatch.Draw(
                    hoverTexture,
                    new Vector2(Card.Position.X - 15, Card.Position.Y - 15),
                    null, Microsoft.Xna.Framework.Color.Yellow, 0.0f, Vector2.Zero, Card.Scale + (0.1f * Card.Scale), SpriteEffects.None, 0.0f);
            }

            Card.Source = new Rectangle((int)Card.Position.X, (int)Card.Position.Y, Card.ImageTexture.Width, Card.ImageTexture.Height);

            //border
            spriteBatch.Draw(
                Card.borderPreview,
                new Vector2(Card.Position.X - 10, Card.Position.Y - 10),
                null, color, 0.0f, Vector2.Zero, Card.Scale, SpriteEffects.None, 0.0f);

            //image
            spriteBatch.Draw(
                Card.ImageTexture,
                Card.Position,
                null, color, 0.0f, Vector2.Zero, Card.Scale, SpriteEffects.None, 0.0f);

            //attack
            Vector2 attackPosition = new Vector2(Card.Source.Left - Card.attackPreview.Width / 2, Card.Source.Bottom - Card.attackPreview.Height / 2);

            spriteBatch.Draw(
                Card.attackPreview,
                attackPosition,
                null, color, 0.0f, Vector2.Zero, Card.Scale, SpriteEffects.None, 0.0f);

            if (Card.Power.HasValue)
            {
                TextureContent.DrawText(spriteBatch, spriteFont, Card.Power.ToString(), Color.Black, color, Card.Scale,
                    new Vector2(attackPosition.X + Card.attackPreview.Width / 2, attackPosition.Y + Card.costPreview.Height / 2));
            }

            //toughness
            Vector2 toughnessPosition = new Vector2(Card.Source.Right - Card.toughnessPreview.Width / 2, Card.Source.Bottom - Card.toughnessPreview.Height / 2);

            spriteBatch.Draw(
                Card.toughnessPreview,
                toughnessPosition,
                null, color, 0.0f, Vector2.Zero, Card.Scale, SpriteEffects.None, 0.0f);


            if (Card.Toughness.HasValue)
            {
                TextureContent.DrawText(spriteBatch, spriteFont, Card.Toughness.Value.ToString(), Color.Black, color, Card.Scale,
                    new Vector2(toughnessPosition.X + Card.toughnessPreview.Width / 2, toughnessPosition.Y + Card.toughnessPreview.Height / 2));
            }

            //Cost
            Vector2 costPosition = new Vector2(Card.Source.Right - Card.costPreview.Width / 2, Card.Source.Top - Card.costPreview.Height / 2);

            spriteBatch.Draw(
                Card.costPreview,
                costPosition,
                null, color, 0.0f, Vector2.Zero, Card.Scale, SpriteEffects.None, 0.0f);

            if (Card.ManaCost.HasValue)
            {
                TextureContent.DrawText(spriteBatch, spriteFont, Card.ManaCost.ToString(), Color.Black, color, Card.Scale,
                    new Vector2(costPosition.X + Card.costPreview.Width / 2, costPosition.Y + Card.costPreview.Height / 2));
            }

            //Name
            Vector2 borderPosition = new Vector2(Card.Source.Left - Card.ImageTexture.Width / 2, Card.Source.Bottom - Card.ImageTexture.Height / 2);

            TextureContent.DrawText(spriteBatch, spriteFont, Card.Name.ToString(), Color.Black, color, Card.Scale / 2,
                new Vector2(borderPosition.X + Card.ImageTexture.Width, Card.Position.Y + 10));
        }

        public void Update()
        {
            Update(() => Power != Card.Power, () => Power = Card.Power);
            Update(() => Toughness != Card.Toughness, () => Toughness = Card.Toughness);
            Update(() => IsVisibleInUi != Card.IsVisibleInUi, () => IsVisibleInUi = Card.IsVisibleInUi);
            Update(() => !Colors.SequenceEqual(Card.Colors), () => Colors = Card.Colors);
            //Update(() => Counters != Card.Counters, () => Counters = Card.Counters);
            Update(() => Level != Card.Level, () => Level = Card.Level);
            Update(() => Type != Card.Type, () => Type = Card.Type);
            Update(() => Damage != Card.Damage, () => Damage = Card.Damage);
            Update(() => IsTapped != Card.IsTapped, () => IsTapped = Card.IsTapped);

            Update(() => HasSummoningSickness != (Card.HasSummoningSickness && Card.Is().Creature && !Card.Has().Charge),
              () => HasSummoningSickness = Card.HasSummoningSickness && Card.Is().Creature && !Card.Has().Charge);
        }

        private static void Update(Func<bool> condition, Action update)
        {
            if (condition()) update();
        }
    }
}