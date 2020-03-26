using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameBuilder{
	public class GameBase : Game{
		public static Texture2D Sprite;
		protected static GraphicsDeviceManager graphics;
		public static int Width{get => graphics.PreferredBackBufferWidth; set {graphics.PreferredBackBufferWidth = value; graphics.ApplyChanges();}}
		public static int Height{get => graphics.PreferredBackBufferHeight; set {graphics.PreferredBackBufferHeight = value; graphics.ApplyChanges();}}
		public static bool IsFullscreen{get => graphics.IsFullScreen; set {graphics.IsFullScreen = value; graphics.ApplyChanges();}}
		public static int MapLimit = 1000;

		protected override void Initialize(){
			Sprite = new Texture2D(GraphicsDevice, 1, 1);
			Sprite.SetData(new Color[] { Color.White });
			base.Initialize();
		}
	}
}
