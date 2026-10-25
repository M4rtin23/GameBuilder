using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static GameBuilder.GameType.FixedView;
using GameBuilder.UI;
namespace GameBuilder.Screens{
	public class SettingsScreen : Screen{
		protected Button Back = new Button("Go Back", () => {GameBuilder.GameType.FixedView.Screen = GameBuilder.GameType.FixedView.Screen.PreviousScreen;});
		protected UIElement[] settings;
		protected UIContainer container{get => new UIContainer(settings, gridWidth, new GameBuilder.Shapes.RectangleF(new Vector2(Width/(gridWidth+1)-64,2*Height/(4+(int)(settings.Length/gridWidth))), new Vector2(Width, Height)));}
		int gridWidth = 1;

		public SettingsScreen(UIElement[] settings, int gridWidth){
			PreviousScreen = GameBuilder.GameType.FixedView.Screen;
			this.settings = settings;
			this.gridWidth = gridWidth;
		}
		public override void Update() {
			container.Update();
			Back.Update(0, 0);
		}
		public override void Draw(SpriteBatch batch) {
			Back.Draw(batch);
			container.Draw(batch);
		}
	}
}
