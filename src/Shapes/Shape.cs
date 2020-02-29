using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBuilder{
	public class Shape{
		protected Color color;
		//int size;
		protected float depth;
		public void SetColor(Color color){
			this.color = color;
		}
		public void SetDepth(float value){
			value = value % 1;
			depth = value;
		}
	}
}