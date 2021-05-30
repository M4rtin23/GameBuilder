using Microsoft.Xna.Framework;

namespace GameBuilder{
	public class Shape{
		protected Color color;
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