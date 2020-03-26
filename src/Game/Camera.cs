using Microsoft.Xna.Framework;
using GameBuilder;
using static GameBuilder.GameBase;

namespace VirtusPecto.Desktop{
	public class Camera{
		static Vector2 pos;

		public static Matrix Follow(Vector2 position) {
			return Matrix.CreateTranslation(-position.X,  -position.Y, 0) * Matrix.CreateTranslation(Width/2, Height/2,0);
		}

		public static Matrix Follow(float x, float y, float scale){
			return Matrix.CreateTranslation(-x*scale,  -y*scale, 0) * Matrix.CreateTranslation(Width/2 , Height/2,0);
		}
		
		public static Matrix Follow(Vector2 position, float speed){
			pos += Motion.Follow(pos, position, speed, 0);
			return Matrix.CreateTranslation(-pos.X, -pos.Y, 0) * Matrix.CreateTranslation(Width/2, Height/2, 0);
		}
	}
}
