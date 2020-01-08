using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameBuilder{
    public class Game1 : Game{
        public static Texture2D Sprite;
        protected override void Initialize(){
			Sprite = new Texture2D(GraphicsDevice, 1, 1);
			Sprite.SetData(new Color[] { Color.White });
            base.Initialize();
        }
    }
}
