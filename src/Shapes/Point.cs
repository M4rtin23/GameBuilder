using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static GameBuilder.GameBase;

namespace GameBuilder.Shapes{
	public class Point : Shape{
		Vector2 position;
		int size;

		public Point(Vector2 position){
			this.position = position;
			color = Color.White;
			size = 1;
		}

		public Point(Vector2 position, int size, Color color){
			this.position = position;
			this.color = color;
			this.size = size;
		}

		public void Draw(SpriteBatch batch){
			batch.Draw(GetDefaultTexture(batch.GraphicsDevice), position, null, color, 0, new Vector2(0.5f, 0.5f), size, SpriteEffects.None, depth);
		}

		#region static
		
		public static void Draw(SpriteBatch batch, float x, float y, int size, Color color, float depth){
			batch.Draw(GetDefaultTexture(batch.GraphicsDevice), new Vector2(x, y), null, color, 0, new Vector2(0.5f, 0.5f), size, SpriteEffects.None, depth);
		}

		public static void Draw(SpriteBatch batch, float x, float y, int size, Color color){
			batch.Draw(GetDefaultTexture(batch.GraphicsDevice), new Vector2(x, y), null, color, 0, new Vector2(0.5f, 0.5f), size, SpriteEffects.None, 0);
		}

		public static void Draw(SpriteBatch batch, float x, float y){
			batch.Draw(GetDefaultTexture(batch.GraphicsDevice), new Vector2(x, y), null, Color.White, 0, new Vector2(0.5f, 0.5f), 4, SpriteEffects.None, 0);
		}

		#endregion

	}
}
