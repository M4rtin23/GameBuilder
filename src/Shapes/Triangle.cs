using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static GameBuilder.GameBase;

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

		public void Draw(SpriteBatch sprBt){
			for(int i = 0; i < 3; i++){
				Line.Draw(sprBt, Vertices[i], Vertices[(i+1)%3], Size, Color, depth);
			}
		}
		public void Draw(GraphicsDevice graphicsDevice){
		VertexPositionColor[] _vertexPositionColors = new VertexPositionColor[3];
			BasicEffect _basicEffect;
			for(int i = 0; i < 3; i++){
				_vertexPositionColors[i] = new VertexPositionColor(new Vector3(Vertices[i], 0), Color);
			}
			_basicEffect = new BasicEffect(graphicsDevice);
			_basicEffect.VertexColorEnabled = true;
			_basicEffect.World = Matrix.CreateOrthographicOffCenter(0, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height, 0, 0, 1);
			_basicEffect.CurrentTechnique.Passes[0].Apply();
		    graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, _vertexPositionColors, 0, 1);

		}


		#region static
		
		public static void Draw(SpriteBatch sprBt, Vector2[] vertices, int size, Color color, float depth){
			for(int i = 0; i < 3; i++){
				Line.Draw(sprBt, vertices[i], vertices[(i+1)%3], size, color, depth);
			}
		}

		public static void Draw(SpriteBatch sprBt, Vector2[] vertices, int size, Color color){
			for(int i = 0; i < 3; i++){
				Line.Draw(sprBt, vertices[i], vertices[(i+1)%3], size, color, 0);
			}
		}

		public static void Draw(SpriteBatch sprBt, Vector2[] vertices){
			for(int i = 0; i < 3; i++){
				Line.Draw(sprBt, vertices[i], vertices[(i+1)%3], 4, Color.White, 0);
			}
		}

		#endregion
	}
}
