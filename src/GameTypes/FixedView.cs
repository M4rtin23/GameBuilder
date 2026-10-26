using Microsoft.Xna.Framework;
using GameBuilder.Shapes;

namespace GameBuilder.GameType{
	public class FixedView : Game{
		protected static GraphicsDeviceManager graphics;
		public static int Width{get => graphics.PreferredBackBufferWidth; set {graphics.PreferredBackBufferWidth = value; graphics.ApplyChanges();}}
		public static int Height{get => graphics.PreferredBackBufferHeight; set {graphics.PreferredBackBufferHeight = value; graphics.ApplyChanges();}}
		public static bool IsFullscreen{get => graphics.IsFullScreen; set {graphics.IsFullScreen = value; graphics.ApplyChanges();}}
		public static GameBuilder.Screens.Screen Screen;

		protected override void Initialize(){
			Shape.CreateTexture(GraphicsDevice);
			base.Initialize();
		}
	}
}
