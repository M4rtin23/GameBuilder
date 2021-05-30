using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBuilder.Shapes{
	public class Line : Shape{
		Vector2[] points;
		int size;
		Vector2 vectorLine{get => points[0] - points[1];}
		public float Slope{get=> (vectorLine.Y)/(vectorLine.X);}
		public float Origin{get => points[0].Y-points[0].X*Slope;}
		public Vector2 Min{get => points[Convert.ToInt16(points[0].X > points[1].X)];}
		public Vector2 Max{get => points[Convert.ToInt16(points[0].X < points[1].X)];}
		public Vector2 Position{get => new Vector2(Min.X, points[Convert.ToInt16(points[0].Y > points[1].Y)].Y);}

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


		public float Funtion(float x){
			return Slope*(x-points[0].X)+points[0].Y;
		}
		public bool Intersects(Line line){
			float x = (Origin - line.Origin) / (line.Slope - Slope);			
			return (Min.X < x && x < Max.X) && (line.Min.X < x && x < line.Max.X);
		}

		public void Draw(SpriteBatch batch){
			float lenght = (points[0] - points[1]).Length();
			float rotation = (float)(-Motion.Angle(points[0], points[1]));
			batch.Draw(GetDefaultTexture(batch.GraphicsDevice), points[0], null, color, rotation, new Vector2(0, 0.5f), new Vector2(lenght, size), SpriteEffects.None, depth);
		}

		#region static

		public static void Draw(SpriteBatch batch, Vector2 point0, Vector2 point1, int size, Color color){
			float lenght = (float)(Motion.Distance(point0, point1));
			float rotation = (float)(-Motion.Angle(point0, point1));
			batch.Draw(GetDefaultTexture(batch.GraphicsDevice), point0, null, color, rotation, new Vector2(0, 0.5f), new Vector2(lenght, size), SpriteEffects.None, 0);
		}

		public static void Draw(SpriteBatch batch, Vector2 point0, Vector2 point1, int size, Color color, float depth){
			float lenght = (float)(Motion.Distance(point0, point1));
			float rotation = (float)(-Motion.Angle(point0, point1));
			batch.Draw(GetDefaultTexture(batch.GraphicsDevice), point0, null, color, rotation, new Vector2(0 ,0.5f), new Vector2(lenght, size), SpriteEffects.None, depth);
		}

		#endregion
	}
}
