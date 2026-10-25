using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameBuilder.Shapes;
namespace GameBuilder.UI{
	public class UIContainer{
		protected UIElement[] settings;
		int gridWidth = 1;
		Vector2 displacement;
		public RectangleF ViewArea;
		public UIContainer(UIElement[] settings, int gridWidth, RectangleF viewArea){
			this.settings = settings;
			this.gridWidth = gridWidth;
			ViewArea = viewArea;
		}
		public void Update() {
			displacement = new Vector2(ViewArea.Width/(gridWidth+1), ViewArea.Height/(4+(int)(settings.Length/gridWidth)));
			for(int i = 0; i < settings.Length; i++){
				settings[i].Update(ViewArea.X + (i % gridWidth)*displacement.X, ViewArea.Y + (i / gridWidth) * displacement.Y);
			}
		}
		public void Draw(SpriteBatch batch) {
			for(int i = settings.Length; i > 0; i--){
				settings[i-1].Draw(batch);
			}
		}
	}
}
