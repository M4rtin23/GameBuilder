using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static GameBuilder.Game1;

namespace GameBuilder{
    public class ObjectBuilder{
        public Vector2 Position;
        protected Vector2 speed, acceleration, origin, scale;
		public Texture2D SpriteIndex;
        public Rectangle Hitbox;
        protected Rectangle rectangle;
		protected float imageIndex, animationSpeed;
		protected SpriteEffects effect = SpriteEffects.None;
		protected float rot = 0;
        private float depth;

        public ObjectBuilder(){
            SpriteIndex = Sprite;
			Position = new Vector2(1, 1);
			origin  = new Vector2(0, 0);
			scale = new Vector2(1, 1);
			
        }
        public virtual void Update(){
            depth = (1/Position.Y+1)/2;
            if(!double.IsNaN(speed.X) && !double.IsNaN(speed.Y)){
                Position += speed += acceleration;
            }
        }
        public virtual void Draw(SpriteBatch sprBt){
            sprBt.Draw(SpriteIndex, Position, rectangle, Color.White, rot, origin, scale, effect, depth);
        }
        protected virtual void animationImage(int frameNumb){
            imageIndex += animationSpeed;
            imageIndex = imageIndex % frameNumb;
        }
        protected virtual void center(int frameNumb){
            origin = new Vector2(SpriteIndex.Width/(2*frameNumb), SpriteIndex.Height/2);
        }
        protected virtual void stripToSprite(int frameNumb){
            rectangle = new Rectangle((int)imageIndex*SpriteIndex.Width/frameNumb, 0, SpriteIndex.Width/frameNumb, SpriteIndex.Height);
        }
        protected bool PreCollision(Rectangle rec){
            return new Rectangle(Hitbox.Location + (speed*2).ToPoint(), Hitbox.Size).Intersects(rec);
        }
        protected bool PreCollisionX(Rectangle rec){
            Rectangle r = Hitbox;
            r.X += (int)speed.X*2;
            return r.Intersects(rec);
        }
        protected bool PreCollisionY(Rectangle rec){
            Rectangle r = Hitbox;
            r.Y += (int)speed.Y*2;
            return r.Intersects(rec);
        }

    }
}
