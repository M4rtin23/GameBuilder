using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameBuilder{
	public class Game1 : Game{
		public static Texture2D Sprite;
		protected static GraphicsDeviceManager graphics;
		protected static SpriteBatch spriteBatch;
		public virtual Matrix Mat{get => Camera.Follow(new Vector2(0,0));}
		public static int Width{get => graphics.PreferredBackBufferWidth; set {graphics.PreferredBackBufferWidth = value; graphics.ApplyChanges();}}
		public static int Height{get => graphics.PreferredBackBufferHeight; set {graphics.PreferredBackBufferHeight = value; graphics.ApplyChanges();}}
		public static bool IsFullscreen{get => graphics.IsFullScreen; set {graphics.IsFullScreen = value; graphics.ApplyChanges();}}
		protected override void Initialize(){
			Sprite = new Texture2D(GraphicsDevice, 1, 1);
			Sprite.SetData(new Color[] { Color.White });
			base.Initialize();
		}
		protected override void Draw(GameTime gameTime){
			spriteBatch.Begin(transformMatrix: Mat, samplerState:  SamplerState.PointClamp, sortMode: SpriteSortMode.BackToFront);
			DrawMap(spriteBatch);
			spriteBatch.End();

			spriteBatch.Begin(samplerState:  SamplerState.PointClamp);
			DrawScreen(spriteBatch);
			spriteBatch.End();
		}
		protected virtual void DrawMap(SpriteBatch batch) {

		}
		protected virtual void DrawScreen(SpriteBatch batch){

		}
	}
}
