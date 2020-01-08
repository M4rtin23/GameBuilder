using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static GameBuilder.Game1;

namespace GameBuilder{
    public class AI{
		Vector2 self, followed;
		float distance, maxSpeed;
	
		public AI(Vector2 self, Vector2 followed, float distance, float speed){
			this.self = self;
			this.followed = followed;
			this.distance = distance;
			this.maxSpeed = speed;
		}
		public float CalculateDistance(){
			return (int)(self-followed).Length();
		}
		public float CalculateAngle(){
			return new Motion(self - followed).GetDirDegrees();
		}
        public Vector2 Follow(){
			if(CalculateDistance() > distance && (followed.X != self.X && followed.Y != self.Y)){
            	float dir = (float) CalculateAngle();
				return new Motion(maxSpeed, dir).GetVectorSpeed();
			}else{
				return Vector2.Zero;
			}
		}
    }
}
