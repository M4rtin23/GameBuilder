using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBuilder.Shapes{
	public class RectangleF : Shape{
		public float X, Y, Width, Height;
		public float Top{get => Y;}
		public float Bottom{get => Y + Height;}
		public float Left{get => X;}
		public float Right{get => X + Width;}

		public Vector2 Location{get => new Vector2(X, Y); set{X = value.X; Y = value.Y;}}
		public Vector2 Size{get => new Vector2(Width, Height); set{Width = value.X; Height = value.Y;}}
		public Vector2 Center{get => Location - Size/2;}

		public static RectangleF Empty{get => new RectangleF(0,0,0,0);}

		public bool IsEmpty{get => this.MemberwiseClone() == RectangleF.Empty;}


		public RectangleF(){}
		
		public RectangleF(Rectangle rectangle){
			X = rectangle.X;
			Y = rectangle.Y;
			Width = rectangle.Width;
			Height = rectangle.Height;
			color = Color.White;
		}

		public RectangleF(Rectangle rectangle, Color color){
			X = rectangle.X;
			Y = rectangle.Y;
			Width = rectangle.Width;
			Height = rectangle.Height;
			this.color = color;
		}

		public RectangleF(Vector2 location, Vector2 size){
			X = location.X;
			Y = location.Y;
			Width = size.X;
			Height = size.Y;
			color = Color.White;
		}
		public RectangleF(float size){
			X = -size/2;
			Y = -size/2;
			Width = size;
			Height = size;
			color = Color.White;
		}
		public RectangleF(float x, float y, float size){
			X = x;
			Y = y;
			Width = size;
			Height = size;
			color = Color.White;
		}
		public RectangleF(Vector2 location, float size){
			X = location.X;
			Y = location.Y;
			Width = size;
			Height = size;
			color = Color.White;
		}
		public RectangleF(float x, float y, float width, float height){
			this.X = x;
			this.Y = y;
			this.Width = width;
			this.Height = height;
			color = Color.White;
		}

		public RectangleF(Vector2 location, Vector2 size, Color color){
			X = location.X;
			Y = location.Y;
			Width = size.X;
			Height = size.Y;
			this.color = color;
		}

		public RectangleF(float x, float y, float width, float height, Color color){
			X = x;
			Y = y;
			Width = width;
			Height = height;
			this.color = color;
		}
		
		public bool Intersects(RectangleF rectangle){
			return rectangle.Left < Right &&
				   Left < rectangle.Right &&
				   rectangle.Top < Bottom &&
				   Top < rectangle.Bottom;
		}

		public bool Intersects(Triangle triangle){
			return  Contains(triangle.Vertices[0])   					         	||
					Contains(triangle.Vertices[1])            						||
					Contains(triangle.Vertices[2])            						||
					triangle.Contains(Location + Size)        						||
					triangle.Contains(new Vector2(X, Bottom)) 						||
					triangle.Intersects(new Line(Location, new Vector2(Right, Y)))	||
					triangle.Intersects(new Line(Location, new Vector2(Right, Bottom)));
		}	

		public bool Contains(Vector2 value){
			return ((((this.X <= value.X) && (value.X < (this.X + this.Width))) && (this.Y <= value.Y)) && (value.Y < (this.Y + this.Height)));
		}

		public void Inflate(float horizontalAmount, float verticalAmount){
			X -= horizontalAmount;
			Y -= verticalAmount;
			Width += horizontalAmount * 2;
			Height += verticalAmount * 2;
		}

		public static RectangleF Inflate(float horizontalAmount, float verticalAmount, RectangleF rectangle){
			rectangle.X -= horizontalAmount;
			rectangle.Y -= verticalAmount;
			rectangle.Width += horizontalAmount * 2;
			rectangle.Height += verticalAmount * 2;
			return rectangle;
		}

		public void Offset(float offsetX, float offsetY){
			X += offsetX;
			Y += offsetY;
		}

		public Rectangle ToRectangle(){
			return new Rectangle(Location.ToPoint(), Size.ToPoint());
		}

		public void Draw(SpriteBatch batch){
			batch.Draw(GetDefaultTexture(batch.GraphicsDevice), Location, null, color, 0, Vector2.Zero, Size, SpriteEffects.None, depth);
		}
		public void Draw(SpriteBatch batch, float depth){
			this.depth = depth;
			batch.Draw(GetDefaultTexture(batch.GraphicsDevice), Location, null, color, 0, Vector2.Zero, Size, SpriteEffects.None, depth);
		}
		public void Draw(SpriteBatch batch, Color color){
			batch.Draw(GetDefaultTexture(batch.GraphicsDevice), Location, null, color, 0, Vector2.Zero, Size, SpriteEffects.None, depth);
		}
		public void Draw(SpriteBatch batch, Color color, float depth){
			this.depth = depth;
			batch.Draw(GetDefaultTexture(batch.GraphicsDevice), Location, null, color, 0, Vector2.Zero, Size, SpriteEffects.None, depth);
		}

		#region static
		
		public static void Draw(SpriteBatch batch, Vector2 Location, Vector2 Size, Color color, float depth){
			batch.Draw(GetDefaultTexture(batch.GraphicsDevice), Location, null, color, 0, Vector2.Zero, Size, SpriteEffects.None, depth);
		}

		public static void Draw(SpriteBatch batch, Vector2 Location, Vector2 Size, Color color){
			batch.Draw(GetDefaultTexture(batch.GraphicsDevice), Location, null, color, 0, Vector2.Zero, Size, SpriteEffects.None, 0);
		}

		public static void Draw(SpriteBatch batch, float x, float y, float width, float height){
			batch.Draw(GetDefaultTexture(batch.GraphicsDevice), new Vector2(x, y), null, Color.White, 0, Vector2.Zero, new Vector2(width, height), SpriteEffects.None, 0);
		}

		public static void Draw(SpriteBatch batch, float x, float y, float size){
			batch.Draw(GetDefaultTexture(batch.GraphicsDevice), new Vector2(x, y), null, Color.White, 0, Vector2.Zero, size, SpriteEffects.None, 0);
		}

		#endregion
	}
}
