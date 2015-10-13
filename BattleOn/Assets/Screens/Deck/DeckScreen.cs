using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using BattleOn;
using BattleOn.Engine;
using Deck = BattleOn.Engine.Deck;

namespace BattleOnGame
{
    public class DeckScreen : GameScreen//, IReceive<DeckGenerationStatus>, IReceive<DeckGenerationError>
    {
        private Dictionary<string, LibraryItem> _libraryItems;
        private GameEngine _game;

        private Texture2D board;
        private SpriteFont fontImpact;
        private Vector2 basePosition = Vector2.Zero;

        private DeckViewModel cardView;
        //private DeckPreviewViewModel deckView;

        private CardViewModel preview;

        public DeckScreen(GameEngine game)
        {
            _game = game;
        }

        public override void Initialize()
        {
            _libraryItems = Cards.All
              .Select(x => new LibraryItem
              {
                  Card = x,
                  Info = new CardInfo(x.Name)
              })
              .ToDictionary(x => x.Info.Name, x => x);

            cardView = new DeckViewModel(_libraryItems, Settings.DECKPOSITION);
            //deckView = new DeckPreviewViewModel(Settings.DECKPREVIEWPOSITION);

            base.Initialize();
        }

        public override void LoadContent()
        {
            ContentManager content = _game.Content;

            board = content.Load<Texture2D>("board");

            basePosition = new Vector2(50, ScreenManager.GraphicsDevice.DisplayMode.Height - 300);
            fontImpact = content.Load<SpriteFont>("Impact");

            TextureContent.MissingImage = content.Load<Texture2D>("Cards//Aatrox.png");
            TextureContent.GetAllCardImages(content, "Cards");

            cardView.Load(content);

            base.LoadContent();
        }

        public bool cardPreview = false;

        public override void HandleInput(GameTime gameTime, InputState input)
        {
            cardView.HandleInput(input, gameTime);
            //deckView.HandleInput(input, gameTime);

            if (preview != null)
                preview.Update(gameTime, true, true);

            CardViewModel hoverView = cardView.GetHoverCard(input);
            if (hoverView != null)
            {
                ScreenManager.Game.Window.Title = hoverView.Name.ToString();

                preview = (CardViewModel)hoverView.Clone();
                preview.Show();
            }
            else
            {
                if(preview != null)
                    preview.Hide();
            }

            //CardViewModel selectedView = cardView.GetSelectedCard(input);
            //if (selectedView != null)
            //{
            //    //deckView.Add(selectedView);
            //}


            if (preview != null)
                preview.Update(gameTime, true, true);

            //MouseState ms = Mouse.GetState();
            //Vector2 mousePosition = new Vector2(ms.Position.X, ms.Position.Y);

            //cardView.HandleInput(input, gameTime);

            //for (int index = 0; index < cardView.Count(); index++)
            //{
            //    CardViewModel view = cardView[index];
            //    view.Update(gameTime, true, true);

            //    if (input.OnMouseOver(view.Card, mousePosition))
            //    {
            //        preview = (CardViewModel)view.Clone();
            //        preview.isVisible = true;

            //        if (input.CurrentCursorState.LeftButton == ButtonState.Pressed &&
            //            input.LastCursorState.LeftButton == ButtonState.Released)
            //        {
            //            cardView.Add(view);
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        if (preview != null)
            //            preview.isVisible = false;
            //    }
            //}

            base.HandleInput(gameTime, input);
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            //for (int index = 0; index < cardView.Count(); index++)
            //{
            //    CardViewModel view = cardView[index];

            //    if (view.Card.Source.Center.X > Resolution.VirtualScreen.X - 100 || view.Card.Source.Center.X < 100)
            //    {
            //        view.isVisible = false;
            //    }
            //    else
            //    {
            //        view.isVisible = true;
            //    }
            //}

            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin(
                SpriteSortMode.Immediate,
                BlendState.NonPremultiplied, 
                null, 
                null, 
                null, 
                null, 
                Resolution.Scale);

            spriteBatch.Draw(
                board,
                new Rectangle(0, 0,
                    ScreenManager.GraphicsDevice.DisplayMode.Width, 
                    ScreenManager.GraphicsDevice.DisplayMode.Height), 
                Color.White);

            cardView.Draw(spriteBatch, fontImpact);

            //deckView.Draw(spriteBatch, fontImpact);

            if (preview != null)
                preview.DrawCard(spriteBatch, fontImpact);


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}