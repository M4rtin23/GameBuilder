using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static GameBuilder.Game1;

namespace GameBuilder{
    public class Triangle : Shape{
		public Vector2[] Vertices;
		public Color Color;
		public int Size;
		public Triangle(Vector2 a, Vector2 b, Vector2 c){
			Vertices = new Vector2[]{a, b, c};
			Color = Color.White;
			Size = 2;
		}
		public Triangle(Vector2 a, Vector2 b, Vector2 c, int size, Color color){
			Vertices = new Vector2[]{a, b, c};
			Color = color;
			Size = size;
		}
		public void Draw(SpriteBatch sprBt){
			for(int i = 0; i < 3; i++){
				Line line = new Line(Vertices[i], Vertices[(i+1)%3], Size, Color);
				line.SetDepth(depth);
				line.Draw(sprBt);
			}
        }

		public bool Intersects(RectangleF rectangle){
			return  rectangle.Contains(Vertices[0])                     ||
					rectangle.Contains(Vertices[0])                     ||
					rectangle.Contains(Vertices[0])                     ||
					Contains(rectangle.Location + rectangle.Size)       ||
					Contains(new Vector2(rectangle.X, rectangle.Bottom))||
					rectangle.checktri(new Triangle(Vertices[0],Vertices[1],Vertices[2]));
		}
		public bool Intersects(Triangle triangle){
			bool a = false;
			for(int i = 0; i < 3; i++){
				Line line = new Line(Vertices[i], Vertices[(i+1)%3]);
				for(float x = line.Min().X; x < line.Max().X; i++){
					if(triangle.Contains( new Vector2(x, (x - line.Min().X)*line.Ratio()+line.Min().Y))){
						a = true;
						break;
					}
				}
			}
			return a;
		}		

        public bool Contains(Vector2 pos){
			float[] y = new float[2];
			bool isFull = false;
			for(int i = 0; i < 3; i++){
				Line line = new Line(Vertices[i], Vertices[(i+1)%3]);
				if(line.Max().X > pos.X && pos.X > line.Min().X){
					Vector2 a = new Vector2(pos.X, (pos.X - line.Min().X)*line.Ratio()+line.Min().Y);
					if(!isFull){
						y[0] = a.Y;
						isFull = true; 
					}else{
						y[1] = a.Y;
					}
					/*Console.WriteLine("" + a + pos + i);
					if(new RectangleF(pos.ToPoint(), new Microsoft.Xna.Framework.Point(64)).Contains(a)){
						new Point(a, 10, Color.Red).Draw(sprBt);
					}*/
				}
			}
			if(y[0] > y[1]){
				float a;
				a = y[0];
				y[0] = y[1];
				y[1] = a;
			}
			isFull = false;
			return (pos.Y > y[0] && pos.Y < y[1]);
        }
    }
}
