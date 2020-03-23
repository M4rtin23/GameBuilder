using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static GameBuilder.Game1;

namespace GameBuilder{
	public class Motion{
		public Vector2 Speed;
		public float Radians{get => direction; set => direction = value;}
		public float Degrees{get => MathHelper.ToDegrees(direction); set { direction = MathHelper.ToRadians(value); CalculateVectorSpeed();}}
		float direction;
		float speed;
		public float MaxSpeed{get => Speed.Length(); set => speed = value;}

		public Motion(Vector2 speed){
			this.Speed = speed;
			this.speed = MaxSpeed;
			CalculateDirection();
		}
		public Motion(float speed, int degreeDir){
			this.speed = speed;
			direction = MathHelper.ToRadians(degreeDir);
			CalculateVectorSpeed();
		}
		public Motion(float speed, float radianDir){
			this.speed = speed;
			direction = radianDir;
			CalculateVectorSpeed();
		}


		public void CalculateSpeedY() {
			Speed.Y = (float)Math.Sin(-direction) * speed;
		}
		public void CalculateSpeedX(){
			Speed.X = (float)Math.Cos(direction) * speed;
		}
		public void CalculateVectorSpeed(){
			CalculateSpeedX();
			CalculateSpeedY();
		}
		public void CalculateDirection() {
			if (Speed.Y > 0){
				direction = (float)(Math.Asin(Speed.X / speed) + Math.PI/2);
			}else{
				direction = (float)(Math.Acos(Speed.X / speed) + Math.PI);
			}
		}
	}
}
