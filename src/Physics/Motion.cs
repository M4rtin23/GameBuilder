using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static GameBuilder.Game1;

namespace GameBuilder{
    public class Motion{
		public Vector2 speed;
		float direction;
		float spd;

		public Motion(Vector2 speed){
			this.speed = speed;
			CalculateSpeed();
			CalculateDirection();
		}
		public Motion(float spd, int degreeDir){
			this.spd = spd;
			direction = MathHelper.ToRadians(degreeDir);
			CalculateVectorSpeed();
		}
		public Motion(float spd, float radianDir){
			this.spd = spd;
			direction = radianDir;
			CalculateVectorSpeed();
		}


		public void CalculateSpeedY() {
			speed.Y = (float)Math.Sin(-direction) * spd;
		}
		public void CalculateSpeedX(){
			speed.X = (float)Math.Cos(direction) * spd;
        }
        public void CalculateVectorSpeed(){
			CalculateSpeedX();
			CalculateSpeedY();
		}
        public void CalculateDirection() {
            if (speed.Y > 0){
                direction = (float)(Math.Asin(speed.X / spd) + Math.PI/2);
            }else{
                direction = (float)(Math.Acos(speed.X / spd) + Math.PI);
            }
        }
		public void CalculateSpeed() {
			spd = (float)speed.Length();
		}
		public Vector2 GetVectorSpeed(){
			return speed;
		}
		public float GetSpeed(){
			return spd;
		}
		public float GetDirDegrees(){
			return MathHelper.ToDegrees(direction);
		}
		public float GetDirRadians(){
			return direction;
		}

    }
}
