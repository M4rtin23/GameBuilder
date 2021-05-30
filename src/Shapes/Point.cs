using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static GameBuilder.GameBase;

namespace GameBuilder{
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

		public void Draw(SpriteBatch sprBt){
			sprBt.Draw(Sprite, position, null, color, 0, new Vector2(0.5f, 0.5f), size, SpriteEffects.None, depth);
		}

		#region static
		
		public static void Draw(SpriteBatch sprBt, float x, float y, int size, Color color, float depth){
			sprBt.Draw(Sprite, new Vector2(x, y), null, color, 0, new Vector2(0.5f, 0.5f), size, SpriteEffects.None, depth);
		}

		public static void Draw(SpriteBatch sprBt, float x, float y, int size, Color color){
			sprBt.Draw(Sprite, new Vector2(x, y), null, color, 0, new Vector2(0.5f, 0.5f), size, SpriteEffects.None, 0);
		}

		public static void Draw(SpriteBatch sprBt, float x, float y){
			sprBt.Draw(Sprite, new Vector2(x, y), null, Color.White, 0, new Vector2(0.5f, 0.5f), 4, SpriteEffects.None, 0);
		}

		#endregion

	}
}
