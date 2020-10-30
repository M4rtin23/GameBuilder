using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static GameBuilder.GameBase;

namespace GameBuilder{
	public class Line : Shape{
		Vector2[] points;
		int size;

		public Line(Vector2 a, Vector2 b){
			points = new Vector2[]{a, b};
			color = Color.White;
			size = 4;
		}

		public Line(Vector2 a, Vector2 b, int size, Color color){
			points = new Vector2[]{a, b};
			this.color = color;
			this.size = size;
		}

		public float Ratio(){
			Vector2 a = points[0] - points[1];
			return (a.Y)/(a.X);
		}

		public Vector2 Position(){
			float x, y;
			if(points[0].X < points[1].X){
				x = points[0].X;
			}else{
				x = points[1].X;	
			}
			if(points[0].Y < points[1].Y){
				y = points[0].Y;
			}else{
				y = points[1].Y;	
			}
			return new Vector2(x, y);
		}

		public Vector2 Min(){
			if(points[0].X < points[1].X){
				return points[0];
			}else{
				return points[1];	
			}
		}

		public Vector2 Max(){
			if(points[0].X < points[1].X){
				return points[1];
			}else{
				return points[0];	
			}
		}

		public void Draw(SpriteBatch sprBt){
			float lenght = (points[0] - points[1]).Length();
			float rotation = (float)(-Motion.Angle(points[0], points[1]));
			sprBt.Draw(Sprite, points[0], null, color, rotation, new Vector2(0 ,0.5f), new Vector2(lenght, size), SpriteEffects.None, depth);
		}

		#region static

		public static void Draw(SpriteBatch sprBt, Vector2 point0, Vector2 point1, int size, Color color){
			float lenght = (float)(Motion.Distance(point0, point1));
			float rotation = (float)(-Motion.Angle(point0, point1));
			sprBt.Draw(Sprite, point0, null, color, rotation, new Vector2(0 ,0.5f), new Vector2(lenght, size), SpriteEffects.None, 0);
		}

		public static void Draw(SpriteBatch sprBt, Vector2 point0, Vector2 point1, int size, Color color, float depth){
			float lenght = (float)(Motion.Distance(point0, point1));
			float rotation = (float)(-Motion.Angle(point0, point1));
			sprBt.Draw(Sprite, point0, null, color, rotation, new Vector2(0 ,0.5f), new Vector2(lenght, size), SpriteEffects.None, depth);
		}

		#endregion
	}
}
