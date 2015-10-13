using System;
using System.Collections.Generic;
using System.Linq;

using BattleOn.Engine;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BattleOnGame
{
    /// <summary>
    /// Helper for reading input from keyboard, gamepad, and touch input. This class 
    /// tracks both the current and previous state of the input devices, and implements 
    /// query methods for high level input actions such as "move up through the menu"
    /// or "pause the game".
    /// </summary>
    public class InputState
    {
        public const int MaxInputs = 4;

        public readonly KeyboardState[] CurrentKeyboardStates;
        public readonly KeyboardState[] LastKeyboardStates;

        public Vector2 cursorPosition;
        public MouseState CurrentCursorState;
        public MouseState LastCursorState;

        public InputState()
        {
            CurrentKeyboardStates = new KeyboardState[MaxInputs];
            LastKeyboardStates = new KeyboardState[MaxInputs];

            CurrentCursorState = new MouseState();
        }


        public void Update()
        {
            for (int i = 0; i < MaxInputs; i++)
            {
                LastKeyboardStates[i] = CurrentKeyboardStates[i];
                CurrentKeyboardStates[i] = Keyboard.GetState((PlayerIndex)i);
            }

            cursorPosition.X = CurrentCursorState.X;
            cursorPosition.Y = CurrentCursorState.Y;

            LastCursorState = CurrentCursorState;

            CurrentCursorState = Mouse.GetState();
        }

        public bool IsNewKeyPress(Keys key, PlayerIndex? controllingPlayer,
                                            out PlayerIndex playerIndex)
        {
            if (controllingPlayer.HasValue)
            {
                // Read input from the specified player.
                playerIndex = controllingPlayer.Value;

                int i = (int)playerIndex;

                return (CurrentKeyboardStates[i].IsKeyDown(key) &&
                        LastKeyboardStates[i].IsKeyUp(key));
            }
            else
            {
                // Accept input from any player.
                return (IsNewKeyPress(key, PlayerIndex.One, out playerIndex) ||
                        IsNewKeyPress(key, PlayerIndex.Two, out playerIndex) ||
                        IsNewKeyPress(key, PlayerIndex.Three, out playerIndex) ||
                        IsNewKeyPress(key, PlayerIndex.Four, out playerIndex));
            }
        }

        public bool IsMenuSelect(PlayerIndex? controllingPlayer,
                                 out PlayerIndex playerIndex)
        {
            return IsNewKeyPress(Keys.Space, controllingPlayer, out playerIndex) ||
                   IsNewKeyPress(Keys.Enter, controllingPlayer, out playerIndex);
        }

        public bool IsMenuCancel(PlayerIndex? controllingPlayer,
                                 out PlayerIndex playerIndex)
        {
            return IsNewKeyPress(Keys.Escape, controllingPlayer, out playerIndex);
        }

        public bool IsMenuUp(PlayerIndex? controllingPlayer)
        {
            PlayerIndex playerIndex;

            return IsNewKeyPress(Keys.Up, controllingPlayer, out playerIndex);
        }

        public bool IsMenuDown(PlayerIndex? controllingPlayer)
        {
            PlayerIndex playerIndex;

            return IsNewKeyPress(Keys.Down, controllingPlayer, out playerIndex);
        }

        public bool IsPauseGame(PlayerIndex? controllingPlayer)
        {
            PlayerIndex playerIndex;

            return IsNewKeyPress(Keys.Escape, controllingPlayer, out playerIndex);
        }

        public bool OnMouseOver(Rectangle card, Vector2 mousePosition)
        {
            int offSet = 20;

            int width = card.Width;
            int height = card.Height;

            int xOffSet = (int)card.X;// -(int)(width / 2);
            int yOffSet = (int)card.Y;// -(int)(height / 2);

            var sceneCoords = mousePosition / Resolution.ScreenScale;

            if (sceneCoords.X >= (xOffSet - offSet) &&
                sceneCoords.X <= (xOffSet + width) &&

                sceneCoords.Y >= (yOffSet - offSet) &&
                sceneCoords.Y <= (yOffSet + height))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool OnMouseOver(Card card, Vector2 mousePosition)
        {
            int offSet = 20;

            int width = card.ImageTexture.Width * (int)card.Scale + offSet;
            int height = card.ImageTexture.Height * (int)card.Scale + offSet;

            int xOffSet = (int)card.Position.X;// -(int)(width / 2);
            int yOffSet = (int)card.Position.Y;// -(int)(height / 2);

            var sceneCoords = mousePosition / Resolution.ScreenScale;

            if (sceneCoords.X >= (xOffSet - offSet) &&
                sceneCoords.X <= (xOffSet + width) &&

                sceneCoords.Y >= (yOffSet - offSet) &&
                sceneCoords.Y <= (yOffSet + height))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PixelCheck(Vector2 pixelPosition, uint[] PixelData, Texture2D spriteTexture, Vector2 spritePosition)
        {
            pixelPosition = cursorPosition - spritePosition;

            if (pixelPosition.X >= 0 && pixelPosition.X < spriteTexture.Width &&
                pixelPosition.Y >= 0 && pixelPosition.Y < spriteTexture.Height)
            {
                spriteTexture.GetData<uint>(0, new Rectangle((int)pixelPosition.X, (int)pixelPosition.Y, (1), (1)), PixelData, 0, 1);

                if (((PixelData[0] & 0xFF000000) >> 24) > 20)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool IsToggled(Keys key)
        {
            if (!LastKeyboardStates[0].IsKeyUp(key) && CurrentKeyboardStates[0].IsKeyDown(key))
                return true;
            else
                return false;
        }
    }
}
