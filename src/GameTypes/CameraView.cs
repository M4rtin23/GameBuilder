using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBuilder.GameType{
	public class CameraView : FixedView{
		protected static SpriteBatch spriteBatch;
		public virtual Matrix Mat{get => InGame.Camera.Follow(new Vector2(0,0));}

		protected override void Draw(GameTime gameTime){
			spriteBatch.Begin(transformMatrix: Mat, samplerState:  SamplerState.PointClamp, sortMode: SpriteSortMode.BackToFront);
			DrawMap(spriteBatch);
			spriteBatch.End();

			spriteBatch.Begin(samplerState:  SamplerState.PointClamp);
			DrawScreen(spriteBatch);
			spriteBatch.End();
			base.Draw(gameTime);
		}

		protected virtual void DrawMap(SpriteBatch batch) {}

		protected virtual void DrawScreen(SpriteBatch batch){}
	}
}
