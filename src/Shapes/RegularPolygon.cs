using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBuilder.Shapes{
	public class RegularPolygon : Shape{
		public Vector2 Position;
		public Vector2[] Vertices;
		public Color Color;
		public int Size;

		public RegularPolygon(int vertices, Vector2 position, float radius, float rotation = 0){
			Vertices = new Vector2[vertices];
			Position = position;
			for(int i = 0; i < vertices; i++){
				Vertices[i] = new Vector2((float)System.Math.Cos(System.Math.Tau/vertices*i+rotation), (float)System.Math.Sin(System.Math.Tau/vertices*i+rotation))*radius;
			}
			Color = Color.White;
			Size = 2;
		}


		//TODO: Intersections

		public void Draw(SpriteBatch batch){
			for(int i = 0; i < Vertices.Length; i++){
				Line.Draw(batch, Vertices[i]+Position, Vertices[(i+1)%Vertices.Length]+Position, Size, Color, depth);
			}
		}

		public void Draw(GraphicsDevice graphicsDevice){
			RasterizerState originalState = graphicsDevice.RasterizerState;
			graphicsDevice.RasterizerState = RasterizerState.CullNone;
			VertexPositionColor[] _vertexPositionColors = new VertexPositionColor[Vertices.Length*3];
			BasicEffect _basicEffect;
			for(int i = 0; i < Vertices.Length; i++){
				_vertexPositionColors[3*i] = new VertexPositionColor(new Vector3(Position, 0), Color);
				_vertexPositionColors[3*i+1] = new VertexPositionColor(new Vector3(Position+Vertices[i], 0), Color);
				_vertexPositionColors[3*i+2] = new VertexPositionColor(new Vector3(Position+Vertices[(i+1)%Vertices.Length], 0), Color);
			}
			_basicEffect = new BasicEffect(graphicsDevice);
			_basicEffect.VertexColorEnabled = true;
			_basicEffect.World = Matrix.CreateOrthographicOffCenter(0, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height, 0, 0, 1);
			_basicEffect.CurrentTechnique.Passes[0].Apply();
		    graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, _vertexPositionColors, 0, Vertices.Length);
			graphicsDevice.RasterizerState = originalState;
		}
	}
}
