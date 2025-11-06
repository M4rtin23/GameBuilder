using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBuilder.Shapes{
	public class Quad : Shape{
		public Vector2[] Vertices = new Vector2[4];
		private Triangle triangle1{get => new Shapes.Triangle(Vertices[0],Vertices[1],Vertices[2]);}
		private Triangle triangle2{get => new Shapes.Triangle(Vertices[1],Vertices[3],Vertices[2]);}

		public Color Color;
		public int Size;

		public Quad(Vector2 a, Vector2 b, Vector2 c, Vector2 d){
			Vertices = new Vector2[]{a, b, c, d};
			Color = Color.White;
			Size = 2;
		}

		public Quad(Vector2 a, Vector2 b, Vector2 c, Vector2 d, int size, Color color){
			Vertices = new Vector2[]{a, b, c, d};
			Color = color;
			Size = size;
		}

		public Quad(Vector2[] vertices){
			Vertices = vertices;
			Color = Color.White;
			Size = 2;
		}
		public Quad(RectangleF rectangle){
			Vertices = new Vector2[]{rectangle.Location, rectangle.Location + Vector2.UnitX * rectangle.Width, rectangle.Location + Vector2.UnitY * rectangle.Height, new Vector2(rectangle.Right, rectangle.Bottom)};
			Color = Color.White;
			Size = 2;
		}

		public bool Intersects(Triangle triangle){
			return triangle1.Intersects(triangle) || triangle2.Intersects(triangle);
		}
		public bool Intersects(RectangleF rectangle){
			return rectangle.Intersects(triangle1) || triangle2.Intersects(triangle2);
		}
		public void Draw(SpriteBatch batch){
			triangle1.Draw(batch);
			triangle2.Draw(batch);
		}
		public void Draw(GraphicsDevice graphicsDevice){
			RasterizerState originalState = graphicsDevice.RasterizerState;
			graphicsDevice.RasterizerState = RasterizerState.CullNone;
			VertexPositionColor[] _vertexPositionColors = new VertexPositionColor[4];
			BasicEffect _basicEffect;
			for(int i = 0; i < 4; i++){
				_vertexPositionColors[i] = new VertexPositionColor(new Vector3(Vertices[i], 0), Color);
			}
			_basicEffect = new BasicEffect(graphicsDevice);
			_basicEffect.VertexColorEnabled = true;
			_basicEffect.World = Matrix.CreateOrthographicOffCenter(0, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height, 0, 0, 1);
			_basicEffect.CurrentTechnique.Passes[0].Apply();
		    graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleStrip, _vertexPositionColors, 0, 2);
			graphicsDevice.RasterizerState = originalState;
		}
	}
}
