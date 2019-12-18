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
            base.Initialize();
        }

        protected override void LoadContent(){
            Sprite = Content.Load<Texture2D>("Sprite");
        }
        protected override void Update(GameTime gameTime){
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime){
            base.Draw(gameTime);
        }

    }
}
