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
		private Triangle self{get => new Triangle(Vertices);}

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

		public Triangle(Vector2[] vertices){
			Vertices = vertices;
			Color = Color.White;
			Size = 2;
		}

		public bool Intersects(Triangle triangle){
			return linesIntersection(triangle) || IsVertexInside(triangle) || triangle.IsVertexInside(self);
		}

		private bool linesIntersection(Triangle triangle){
			for(int i = 0; i < 3; i++){
				Line line = new Line(Vertices[i], Vertices[(i+1)%3]);
				for(int j = 0; j < 3; j++){
					Line line2 = new Line(triangle.Vertices[j], triangle.Vertices[(j+1)%3]);
					if(line2.Intersects(line)){
						return true;
					}
				}
			}
			return false;
		}

		public bool Intersects(Line line){
			for(int i = 0; i < 3; i++){
				Line line2 = new Line(Vertices[i], Vertices[(i+1)%3]);
				if(line.Intersects(line2)){
					return true;
				}
			}
			return false;
		}

		public bool IsVertexInside(Triangle triangle){
			for(int i = 0; i < 3; i++){
				if(Contains(triangle.Vertices[i])){
					return true;
				}
			}
			return false;
		}

		public int VerticesInside(Triangle triangle){
			int v = 0;
			for(int i = 0; i < 3; i++){
				if(Contains(triangle.Vertices[i])){
					v++;
				}
			}
			return v;
		}
	
		public bool Contains(Vector2 point){
			float[] yValues = new float[2];
			int results = 0;
			for(int i = 0; i < 3; i++){
				Line line = new Line(Vertices[i], Vertices[(i+1)%3]);
				if(line.Min.X < point.X && point.X < line.Max.X){
					float y = line.Funtion(point.X);
					yValues[results] = y;
					results++;
				}
			}
			if(results == 0){
				return false;
			}
			if(yValues[0] > yValues[1]){
				float switcher = yValues[0];
				yValues[0] = yValues[1];
				yValues[1] = switcher;
			}
			return yValues[0] < point.Y && point.Y < yValues[1];
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
