using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBuilder.Shapes{
	public class Shape{
		protected Color color;
		protected float depth;
		public static Texture2D DefaultTexture;
		
		public static void CreateTexture(GraphicsDevice graphics){
			DefaultTexture = GetDefaultTexture(graphics);
		}

		public void SetColor(Color color){
			this.color = color;
		}

		public void SetDepth(float value){
			value = value % 1;
			depth = value;
		}

		public static Texture2D GetDefaultTexture(GraphicsDevice graphics){
			Texture2D texture = new Texture2D(graphics, 1, 1);
			texture.SetData(new Color[] { Color.White });
			return texture;
		}
	}
}