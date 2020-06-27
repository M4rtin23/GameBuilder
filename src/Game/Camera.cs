using Microsoft.Xna.Framework;
using static GameBuilder.GameBase;

namespace GameBuilder{
	public class Camera{
		public static Vector2 Position;

		public static Matrix Follow(Vector2 position) {
			return Matrix.CreateTranslation(-position.X,  -position.Y, 0) * Matrix.CreateTranslation(Width/2, Height/2,0);
		}

		public static Matrix Follow(float x, float y, float scale){
			return Matrix.CreateTranslation(-x*scale,  -y*scale, 0) * Matrix.CreateTranslation(Width/2 , Height/2,0);
		}
		
		public static Matrix Follow(Vector2 position, float speed){
			Position += Motion.Follow(Position, position, speed, 0);
			return Matrix.CreateTranslation(-Position.X, -Position.Y, 0) * Matrix.CreateTranslation(Width/2, Height/2, 0);
		}

		public static Matrix LimitedFollow(Vector2 position){
			if(position.X < (MapLimit-Width)/2 && position.X > (-MapLimit+Width)/2)
			Position.X = position.X;
			if(position.Y < (MapLimit-Height)/2 && position.Y > (-MapLimit+Height)/2)
			Position.Y = position.Y;
			return Matrix.CreateTranslation(-Position.X, -Position.Y, 0) * Matrix.CreateTranslation(Width/2, Height/2, 0);
		}
	}
}
