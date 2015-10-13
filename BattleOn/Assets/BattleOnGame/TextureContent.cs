using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using BattleOn;
using BattleOn.Engine;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace BattleOnGame
{
    public static class TextureContent
    {
        public static void DrawText(SpriteFont SpriteFont, SpriteBatch SpriteBatch, string Text, Microsoft.Xna.Framework.Color backColor, Microsoft.Xna.Framework.Color frontColor, float scale, float rotation, Vector2 position)
        {
            //If we want to draw the text from the origin we need to find that point, otherwise you can set all origins to Vector2.Zero.

            Vector2 origin = new Vector2(SpriteFont.MeasureString(Text).X / 2, SpriteFont.MeasureString(Text).Y / 2);

            //These 4 draws are the background of the text and each of them have a certain displacement each way.

            SpriteBatch.DrawString(SpriteFont, Text, position + new Vector2(1 * scale, 1 * scale),//Here’s the displacement
            backColor,
            rotation,
            origin,
            scale,
            SpriteEffects.None,
            0.0f);

            SpriteBatch.DrawString(SpriteFont, Text, position + new Vector2(-1 * scale, -1 * scale),
            backColor,
            rotation,
            origin,
            scale,
            SpriteEffects.None,
            0.0f);

            SpriteBatch.DrawString(SpriteFont, Text, position + new Vector2(-1 * scale, 1 * scale),
            backColor,
            rotation,
            origin,
            scale,
            SpriteEffects.None,
            0.0f);

            SpriteBatch.DrawString(SpriteFont, Text, position + new Vector2(1 * scale, -1 * scale),
            backColor,
            rotation,
            origin,
            scale,
            SpriteEffects.None,
            0.0f);

            //This is the top layer which we draw in the middle so it covers all the other texts except that displacement.

            SpriteBatch.DrawString(
                SpriteFont,
                Text,
                position,
                frontColor,
                rotation,
                origin,
                scale,
                SpriteEffects.None,
                0.0f);
        }

        public static void DrawText(SpriteBatch spritebatch, SpriteFont font, string text, Color backColor, Color frontColor, float scale, Vector2 position)
        {
            Vector2 origin = new Vector2(font.MeasureString(text).X / 2, font.MeasureString(text).Y / 2);

            spritebatch.DrawString(font, text, position + new Vector2(1 * scale, 1 * scale), backColor, 0, origin, scale, SpriteEffects.None, 1f);
            spritebatch.DrawString(font, text, position + new Vector2(-1 * scale, 1 * scale), backColor, 0, origin, scale, SpriteEffects.None, 1f);
            //spriteBatch.DrawString(font, text, position + new Vector2(-1 * scale, -1 * scale), backColor, 0, origin, scale, SpriteEffects.None, 1f);
            //spriteBatch.DrawString(font, text, position + new Vector2(1 * scale, -1 * scale), backColor, 0, origin, scale, SpriteEffects.None, 1f);          

            spritebatch.DrawString(font, text, position, frontColor, 0, origin, scale, SpriteEffects.None, 0f);
        }

        public static StringBuilder ApendText(int textLength, string text)
        {
            int myLimit = textLength;
            string[] words = text.Split(' ');
            StringBuilder newSentence = new StringBuilder();
            string line = "";
            foreach (string word in words)
            {
                if ((line + word).Length > myLimit)
                {
                    newSentence.AppendLine(line);
                    line = "";
                }

                line += string.Format("{0} ", word);
            }

            if (line.Length > 0) newSentence.AppendLine(line);

            return newSentence;
        }

        public static Texture2D MissingImage;
        public static Dictionary<string, Texture2D> spriteContent;

        public static Dictionary<string, Texture2D> spriteRarity;

        public static void GetAllCardImages(ContentManager content, string folder)
        {
            spriteContent = TextureContent.LoadListContent<Texture2D>(content, folder);
        }

        public static void GetAllCardRarity(ContentManager content, string folder)
        {
            spriteRarity = TextureContent.LoadListContent<Texture2D>(content, folder);
        }

        public static Texture2D GetCardImage(string name)
        {
            if (spriteContent.ContainsKey(name))
            {
                return spriteContent[name];
            }
            else
            {
                return MissingImage;
            }
        }

        public static Texture2D GetCardRarity(Card card)
        {
            if (card.Rarity == null)
            {
                card.Rarity = Rarity.Common;
            }
            else
            {
                if (spriteRarity.ContainsKey(card.Rarity.Value.ToString()))
                {
                    return spriteRarity[card.Rarity.Value.ToString()];
                }
            }

            return spriteRarity["Common"];
        }

        public static Dictionary<string, T> LoadListContent<T>(this ContentManager contentManager, string contentFolder)
        {
            DirectoryInfo dir = new DirectoryInfo(contentManager.RootDirectory + "/" + contentFolder);
            if (!dir.Exists)
                throw new DirectoryNotFoundException();
            Dictionary<String, T> result = new Dictionary<String, T>();

            FileInfo[] files = dir.GetFiles("*.*");
            foreach (FileInfo file in files)
            {
                string key = Path.GetFileNameWithoutExtension(file.Name);

                result[key] = contentManager.Load<T>(contentFolder + "/" + key);
            }
            return result;
        }
    }
}
