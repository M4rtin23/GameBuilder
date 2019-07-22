using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameBuilder{
    public class ObjectBuilder{
        public Vector2 Position;
        private Vector2 speed, acceleration;
		public Texture2D SpriteIndex;
        public Rectangle Hitbox;
		protected double imageIndex, animationSpeed;
		protected SpriteEffects effect;
		protected float vspeed, hspeed;

        public ObjectBuilder(){

        }
        public virtual void Update(){
			
            Position += speed += acceleration;
        }
        public virtual void Draw(){
            
        }
        private void animationImage(int frameNumb){
            imageIndex += animationSpeed;
            imageIndex = imageIndex % frameNumb;
        }
    }
}
