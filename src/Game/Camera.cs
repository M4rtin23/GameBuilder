using Microsoft.Xna.Framework;
using static GameBuilder.Game1;

namespace VirtusPecto.Desktop{
	public class Camera{
		static Vector2 pos;
		public static Matrix Follow(Vector2 position) {
			return Matrix.CreateTranslation(-position.X,  -position.Y, 0)*Matrix.CreateTranslation(Width/2, Height/2,0);
		}
		public static Matrix Follow(Vector2 position, float Speed){
			pos += new GameBuilder.AI(pos, Speed).Follow(position);
			return Matrix.CreateTranslation(-pos.X, -pos.Y, 0) * Matrix.CreateTranslation(Width/2, Height/2, 0);
		}
	}
}
