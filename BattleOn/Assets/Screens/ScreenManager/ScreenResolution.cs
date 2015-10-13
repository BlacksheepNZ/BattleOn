using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BattleOnGame
{
    /// <summary>
    /// Resolution
    /// </summary>
    public static class Resolution
    {
        private static Vector3 ScalingFactor;
        private static int _preferredBackBufferWidth;
        private static int _preferredBackBufferHeight;

        /// <summary>
        /// The virtual screen size. Default is 1920*1080
        /// </summary>
        public static Vector2 VirtualScreen = new Vector2(1920, 1080);

        /// <summary>
        /// The screen scale
        /// </summary>
        public static Vector2 ScreenAspectRatio = new Vector2(1, 1);

        /// <summary>
        /// The scale used for beginning the SpriteBatch.
        /// </summary>
        public static Matrix Scale;

        /// <summary>
        /// The scale result of merging VirtualScreen with WindowScreen.
        /// </summary>
        public static Vector2 ScreenScale;

        /// <summary>
        /// Updates the specified graphics device to use the configured resolution.
        /// </summary>
        /// <param name="device">The device.</param>
        /// <exception cref="System.ArgumentNullException">device</exception>
        public static void Update(GraphicsDeviceManager device)
        {
            if (device == null) throw new ArgumentNullException("device");

            //Calculate ScalingFactor
            _preferredBackBufferWidth = device.PreferredBackBufferWidth;
            float widthScale = _preferredBackBufferWidth / VirtualScreen.X;

            _preferredBackBufferHeight = device.PreferredBackBufferHeight;
            float heightScale = _preferredBackBufferHeight / VirtualScreen.Y;

            ScreenScale = new Vector2(widthScale, heightScale);

            ScreenAspectRatio = new Vector2(widthScale / heightScale);
            ScalingFactor = new Vector3(widthScale, heightScale, 1);
            Scale = Matrix.CreateScale(ScalingFactor);
            device.ApplyChanges();
        } 


        /// <summary>
        /// <para>Determines the draw scaling.</para>
        /// <para>Used to make the mouse scale correctly according to the virtual resolution,
        /// no matter the actual resolution.</para>
        /// <para>Example: 1920x1080 applied to 1280x800: new Vector2(1.5f, 1,35f)</para>
        /// </summary>
        /// <returns></returns>
        public static Vector2 DetermineDrawScaling()
        {
            var x = _preferredBackBufferWidth / VirtualScreen.X;
            var y = _preferredBackBufferHeight / VirtualScreen.Y;
            return new Vector2(x, y);
        }

        public static GraphicsDeviceManager ToggleScreenResolution(string ScreenResolutionText, GraphicsDeviceManager graphics)
        {
            switch (ScreenResolutionText)
            {
                case "800x600":
                    graphics.PreferredBackBufferWidth = 800;
                    graphics.PreferredBackBufferHeight = 600;
                    break;
                case "1024x768":
                    graphics.PreferredBackBufferWidth = 1024;
                    graphics.PreferredBackBufferHeight = 768;
                    break;
                case "1280x800":
                    graphics.PreferredBackBufferWidth = 1280;
                    graphics.PreferredBackBufferHeight = 800;
                    break;
                case "1280x1024":
                    graphics.PreferredBackBufferWidth = 1280;
                    graphics.PreferredBackBufferHeight = 1024;
                    break;
                case "1600x1200":
                    graphics.PreferredBackBufferWidth = 1600;
                    graphics.PreferredBackBufferHeight = 1200;
                    break;
                case "1920x1080":
                    graphics.PreferredBackBufferWidth = 1920;
                    graphics.PreferredBackBufferHeight = 1080;
                    break;
            }
            return graphics;
        }
    }
}
