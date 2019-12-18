﻿using Microsoft.Xna.Framework;
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
//            depth = (1/Position.Y+1)/2;
            depth = (-Position.Y-Position.X/2)/10000+1;
            if(!double.IsNaN(acceleration.X) && !double.IsNaN(acceleration.Y)){
                speed += acceleration;
            }

            if(!double.IsNaN(speed.X) && !double.IsNaN(speed.Y)){
                Position += speed;
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
    }
}
