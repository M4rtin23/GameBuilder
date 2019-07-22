using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static GameBuilder.Builder;

namespace GameBuilder{
    public class Game1 : Game{
        public static Texture2D Sprite;

        public Game1(){
            Content.RootDirectory = "Content";
        }

        protected override void Initialize(){
            Sprite = Content.Load<Texture2D>("Sprite");

            base.Initialize();
        }
    }
}
