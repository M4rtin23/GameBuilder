using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static GameBuilder.Game1;

namespace GameBuilder{
    public class Physics{
		Rectangle hitbox, otherHitbox;
		Vector2 speed;
		public Physics(Rectangle hitbox, Rectangle otherHitbox, Vector2 speed){
			this.hitbox = hitbox;
			this.otherHitbox = otherHitbox;
			this.speed = speed;
		}
        public bool IsCollision(){
            return new Rectangle(hitbox.X+(int)speed.X, hitbox.Y+(int)speed.Y, hitbox.Width, hitbox.Height).Intersects(otherHitbox);
        }
        public bool IsCollisionX(){
            return new Rectangle(hitbox.X+(int)speed.X, hitbox.Y, hitbox.Width, hitbox.Height).Intersects(otherHitbox);
        }
        public bool IsCollisionY(){
            return new Rectangle(hitbox.X, hitbox.Y+(int)speed.Y, hitbox.Width, hitbox.Height).Intersects(otherHitbox);
        }
    }
}
