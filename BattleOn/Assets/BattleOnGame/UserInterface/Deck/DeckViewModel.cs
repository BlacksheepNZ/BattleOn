using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleOn.Engine;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BattleOnGame
{
    public class CardPreview
    {
        CardViewModel item;

        public CardPreview(CardViewModel item)
        {
            this.item = item;
        }

        public void Show()
        {
            item.isVisible = true;
        }

        public void Hide()
        {
            item.isVisible = false;
        }

        public void Update(GameTime gameTime)
        {
            item.Update(gameTime, true, false);
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            item.Card.Position = Settings.PREVIEWPOSITION;
            item.DrawCard(spriteBatch, spriteFont);
        }
    }

    public class DeckPreviewViewModel
    {
        private List<CardViewModel> view;
        private Vector2 drawPosition;

        //private CardPreview preview;

        public DeckPreviewViewModel(Vector2 drawPosition)
        {
            this.view = new List<CardViewModel>();
            this.drawPosition = drawPosition;
        }

        public void Add(CardViewModel value)
        {
            if (view.Count() >= Settings.MAXCARDS) return;

            //var duplicateKeys = view.GroupBy(x => x)
            //            .Where(group => group.Count() > 3)
            //            .Select(group => group.Key).Count() >= Settings.MAXDUPLICATES;

            //var maxDups = (view.Where(x => x == view).Select(x => x).Count() >= Settings.MAXDUPLICATES);
            //if (duplicateKeys == true) return;

            view.Add(value);
        }

        //private void Sort()
        //{
        //    query = cards.GroupBy(x => x)
        //      .Where(g => g.Count() >= 1)
        //      .OrderBy(x => x.Key.ManaCost)
        //      .ToDictionary(x => x.Key, y => y.Count());

        //}

        //public void Remove(CardViewModel card)
        //{
        //    cards.Remove(card);

        //    Sort();
        //}

        public void HandleInput(InputState input, GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            MouseState ms = Mouse.GetState();
            Vector2 mousePosition = new Vector2(ms.Position.X, ms.Position.Y);

            //if (preview != null)
            //    preview.Update(gameTime);

            if (view != null)
            {
                int index = 0;
                foreach (var items in view)
                {
                    //if (input.OnMouseOver(items.Card.Source, mousePosition))
                    //{
                    //    preview = new CardPreview(items);
                    //    preview.Show();
                    //}
                    //else
                    //{
                    //    if (preview != null)
                    //        preview.Hide();
                    //}

                    index++;
                }
            }

            //if (input.CurrentKeyboardStates[0].IsKeyDown(Keys.Left))
            //{
            //    drawPosition.X += 500 * elapsed;
            //}
            //if (input.CurrentKeyboardStates[0].IsKeyDown(Keys.Right))
            //{
            //    drawPosition.X -= 500 * elapsed;
            //}

            //if (view != null)
            //{
            //    drawPosition.X = Vector2.Clamp(
            //        drawPosition,
            //        new Vector2(-(view.Count - 7) * 160, drawPosition.Y),
            //        new Vector2(100, drawPosition.Y)).X;
            //}
        }

        //public void Load(ContentManager content)
        //{
        //    if (view != null)
        //    {
        //        foreach (var items in view)
        //        {
        //            var value = new CardViewModel(items.Card);

        //            value.LoadContent(content);
        //        }
        //    }
        //}

        public void Draw(SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            //if (preview != null)
            //    preview.Draw(spriteBatch, spriteFont);

            int i = 0;

            if (view != null)
            {
                foreach (var items in view)
                {
                    var value = new CardViewModel(items.Card);

                    value.Card.Position = new Vector2(drawPosition.X, drawPosition.Y + (i * 50));
                    value.Card.Source = new Rectangle((int)value.Card.Position.X, (int)value.Card.Position.Y, 100, 50);

                    DrawCard(spriteBatch, spriteFont, value.Card);

                    Vector2 countPosition = new Vector2(value.Card.Source.Right - value.Card.costPreview.Width / 2, value.Card.Source.Top - value.Card.costPreview.Height / 2);

                    //TextureContent.DrawText(spriteBatch, spriteFont, view.Sum(list => list.Count()) + " / " + Settings.MAXCARDS.ToString(), Color.Black, Color.White, 1.0f, new Vector2(drawPosition.X + 50, drawPosition.Y - 50));

                    i++;
                }
            }
        }

        public void DrawCard(SpriteBatch spriteBatch, SpriteFont spriteFont, Card card)
        {
            Color color = new Color((byte)255, (byte)255, (byte)255, (byte)255);

            //Cost
            Vector2 costPosition = new Vector2(card.Source.Left - card.costPreview.Width / 2, card.Source.Top - card.costPreview.Height / 2);

            spriteBatch.Draw(
                card.costPreview,
                costPosition,
                null, color, 0.0f, Vector2.Zero, card.Scale, SpriteEffects.None, 0.0f);

            if (card.ManaCost.HasValue)
            {
                TextureContent.DrawText(spriteBatch, spriteFont, card.ManaCost.Value.ToString(), Color.Black, color, card.Scale,
                    new Vector2(costPosition.X + card.costPreview.Width / 2, costPosition.Y + card.costPreview.Height / 2));
            }

            //Name
            Vector2 borderPosition = new Vector2(card.Source.Left - card.ImageTexture.Width / 2, card.Source.Center.Y - card.ImageTexture.Height / 2);

            TextureContent.DrawText(spriteBatch, spriteFont, card.Name.ToString(), Color.Black, color, card.Scale / 2,
                new Vector2(borderPosition.X + card.ImageTexture.Width, card.Position.Y));
        }
    }

    public class DeckViewModel
    {
        //private Dictionary<string, LibraryItem> view;
        private Vector2 drawPosition;

        //private CardPreview preview;

        List<CardViewModel> cards = new List<CardViewModel>();

        public DeckViewModel(Dictionary<string, LibraryItem> view, Vector2 drawPosition) 
        {
            //this.view = view;
            this.drawPosition = drawPosition;

            cards = new List<CardViewModel>();

            if (view != null)
            {
                foreach (var items in view)
                {
                    cards.Add(new CardViewModel(items.Value.Card));
                }
            }
        }

        //Dictionary<CardViewModel, int> query = new Dictionary<CardViewModel, int>();

        //public void Add(CardViewModel card)
        //{
        //    if (cards.Count() >= Settings.MAXCARDS) return;

        //    var maxDups = (cards.Where(x => x == card).Select(x => x).Count() >= Settings.MAXDUPLICATES);
        //    if (maxDups == true) return;

        //    cards.Add(card);

        //    Sort();
        //}

        //private void Sort()
        //{
        //    query = cards.GroupBy(x => x)
        //      .Where(g => g.Count() >= 1)
        //      .OrderBy(x => x.Key.ManaCost)
        //      .ToDictionary(x => x.Key, y => y.Count());

        //}

        //public void Remove(CardViewModel card)
        //{
        //    cards.Remove(card);

        //    Sort();
        //}

        public CardViewModel GetSelectedCard(InputState input)
        {
            MouseState ms = Mouse.GetState();
            Vector2 mousePosition = new Vector2(ms.Position.X, ms.Position.Y);

            foreach (var item in cards)
            {
                if (input.OnMouseOver(item.Card.Source, mousePosition))
                {
                    if (input.CurrentCursorState.LeftButton == ButtonState.Pressed &&
                        input.LastCursorState.LeftButton == ButtonState.Released)
                    {
                        return item;
                    }
                }
            }

            return null;
        }

        public CardViewModel GetHoverCard(InputState input)
        {
            MouseState ms = Mouse.GetState();
            Vector2 mousePosition = new Vector2(ms.Position.X, ms.Position.Y);

            foreach (var item in cards)
            {
                if (input.OnMouseOver(item.Card.Source, mousePosition))
                {
                    return item;

                }
            }

            return null;
        }

        public void HandleInput(InputState input, GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            MouseState ms = Mouse.GetState();
            Vector2 mousePosition = new Vector2(ms.Position.X, ms.Position.Y);



            //if (preview != null)
                //preview.Update(gameTime);


            //foreach (var item in cards)
            //{
            //    item.Card = GetHoverCard(input);



            //    if (input.OnMouseOver(item.Card.Source, mousePosition))
            //    {
            //        GetSelectedCard(input);


            //        //preview = (CardViewModel)item.Clone();
            //        //preview.Show();
            //        return;
            //    }
            //    else
            //    {
            //        //if (preview != null)
            //            //preview.Hide();
            //    }
            //}
            

            if (input.CurrentKeyboardStates[0].IsKeyDown(Keys.Left))
            {
                drawPosition.X += 500 * elapsed;
            }
            if (input.CurrentKeyboardStates[0].IsKeyDown(Keys.Right))
            {
                drawPosition.X -= 500 * elapsed;
            }

            drawPosition.X = Vector2.Clamp(
                drawPosition,
                new Vector2(-(cards.Count - 7) * 160, drawPosition.Y),
                new Vector2(100, drawPosition.Y)).X;
        }

        public void Load(ContentManager content)
        {
            foreach (var items in cards)
            {
                items.LoadContent(content);
            }
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            //if(preview != null)
                //preview.Draw(spriteBatch, spriteFont);

                int index = 0;

                foreach (var item in cards)
                {
                    //if (direction == Direction.LeftToRight)
                    //{
                    item.Card.Position = new Vector2(drawPosition.X + (index * 160), drawPosition.Y);
                    //value.Card.Source = new Rectangle((int)value.Card.Position.X, (int)value.Card.Position.Y, value.Card.ImageTexture.Width, value.Card.ImageTexture.Height);

                    item.DrawCard(spriteBatch, spriteFont);
                    //}
                    //if (direction == Direction.UpToDown)
                    //{
                    //    value.Card.Position = new Vector2(drawPosition.X, drawPosition.Y + (index * 50));
                    //}

                    index++;
                }
            


            //int i = 0;

            //if (view != null)
            //{
            //    foreach (var items in view)
            //    {
            //        var key = items.Key;
            //        var value = new CardViewModel(items.Value.Card);

            //        value.Card.Position = new Vector2(drawPosition.X + (i * 160), drawPosition.Y);
            //        //value.Card.Position = new Vector2(basePosition.X, basePosition.Y + (i * 50));
            //        value.Card.Source = new Rectangle((int)value.Card.Position.X, (int)value.Card.Position.Y, 100, 50);

            //        DrawCard(spriteBatch, spriteFont, value.Card);

            //        Vector2 countPosition = new Vector2(value.Card.Source.Right - value.Card.costPreview.Width / 2, value.Card.Source.Top - value.Card.costPreview.Height / 2);
            //        TextureContent.DrawText(spriteBatch, spriteFont, value.Card.ToString(), Color.Black, value.Card.Color, value.Card.Scale,
            //            new Vector2(countPosition.X + value.Card.costPreview.Width / 2, countPosition.Y + value.Card.costPreview.Height / 2));

            //        i++;
            //    }
            //}

            //TextureContent.DrawText(spriteBatch, spriteFont, view.Values.Sum(list => list.Count) + " / " + Settings.MAXCARDS.ToString(), Color.Black, Color.White, 1.0f, new Vector2(drawPosition.X + 50, drawPosition.Y - 50));
        }

        public void DrawCard(SpriteBatch spriteBatch, SpriteFont spriteFont, Card card)
        {
            Color color = new Color((byte)255, (byte)255, (byte)255, (byte)255);

            //Cost
            Vector2 costPosition = new Vector2(card.Source.Left - card.costPreview.Width / 2, card.Source.Top - card.costPreview.Height / 2);

            spriteBatch.Draw(
                card.costPreview,
                costPosition,
                null, color, 0.0f, Vector2.Zero, card.Scale, SpriteEffects.None, 0.0f);

            if (card.ManaCost.HasValue)
            {
                TextureContent.DrawText(spriteBatch, spriteFont, card.ManaCost.Value.ToString(), Color.Black, color, card.Scale,
                    new Vector2(costPosition.X + card.costPreview.Width / 2, costPosition.Y + card.costPreview.Height / 2));
            }

            //Name
            Vector2 borderPosition = new Vector2(card.Source.Left - card.ImageTexture.Width / 2, card.Source.Center.Y - card.ImageTexture.Height / 2);

            TextureContent.DrawText(spriteBatch, spriteFont, card.Name.ToString(), Color.Black, color, card.Scale / 2,
                new Vector2(borderPosition.X + card.ImageTexture.Width, card.Position.Y));
        }
    }
}
