using Microsoft.Xna.Framework;
using static GameBuilder.GameBase;

namespace GameBuilder{
	public class Camera{
		public static Matrix Follow(Vector2 pos) {
			return Matrix.CreateTranslation(-pos.X,  -pos.Y, 0) * Matrix.CreateTranslation(Width/2, Height/2,0);
		}

		
	}
}
