using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static GameBuilder.Game1;

namespace GameBuilder{
    public class ObjectBuilder{
        public Vector2 Position;
        protected Vector2 speed, acceleration, origin, scale;
		public Texture2D SpriteIndex;
        public RectangleF Hitbox = new RectangleF();
		public RectangleF FastHitbox {get => new RectangleF(Position - origin*scale, rectangle.Size * scale);}
        protected RectangleF rectangle = new RectangleF();
		protected float imageIndex, animationSpeed;
		protected SpriteEffects effect = SpriteEffects.None;
		protected float rot = 0, maxSpeed;
		protected Color color = Color.White;
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
            sprBt.Draw(SpriteIndex, Position, rectangle.ToRectangle(), color, rot, origin, scale, effect, depth);
        }
        protected virtual void animationImage(int frameNumb){
            imageIndex += animationSpeed;
            imageIndex = imageIndex % frameNumb;
        }
        protected virtual void center(int frameNumb){
            origin = new Vector2(SpriteIndex.Width/(2*frameNumb), SpriteIndex.Height/2);
        }
        protected virtual void stripSprite(int frameNumb){
            rectangle = new RectangleF((int)imageIndex*SpriteIndex.Width/frameNumb, 0, SpriteIndex.Width/frameNumb, SpriteIndex.Height);
        }
		protected bool PreCollision(RectangleF rec){
            return new RectangleF(Hitbox.Location + (speed*2), Hitbox.Size).Intersects(rec);
        }
        protected bool PreCollisionX(RectangleF rec){
            RectangleF r = new RectangleF(Hitbox.Location, Hitbox.Size);
            r.X += speed.X;
            return r.Intersects(rec);
        }
        protected bool PreCollisionY(RectangleF rec){
            RectangleF r = new RectangleF(Hitbox.Location, Hitbox.Size);
            r.Y += speed.Y;
            return r.Intersects(rec);
        }
    }
}
