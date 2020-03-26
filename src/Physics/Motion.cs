using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static GameBuilder.GameBase;

namespace GameBuilder{
	public class Motion{
		public Vector2 Speed;
		float direction;

		public float Radians{get => direction; set { direction = value; CalculateVectorSpeed(MaxSpeed);}}
		public float Degrees{get => MathHelper.ToDegrees(direction); set { direction = MathHelper.ToRadians(value); CalculateVectorSpeed(MaxSpeed);}}
		public float MaxSpeed{get => Speed.Length(); set => CalculateVectorSpeed(value);}

		public Motion(Vector2 speed){
			this.Speed = speed;
			CalculateDirection();
		}

		public Motion(float speed, int degreeDir){
			MaxSpeed = speed;
			Degrees = degreeDir;
		}

		public Motion(float speed, float radianDir){
			MaxSpeed = speed;
			Radians = radianDir;
		}

		public void CalculateVectorSpeed(float  maxSpeed){
			float speed = maxSpeed;
			Speed.X = (float)Math.Cos(direction) * speed;
			Speed.Y = (float)Math.Sin(-direction) * speed;
		}

		public void CalculateDirection() {
			if (Speed.Y > 0){
				direction = (float)(Math.Asin(Speed.X / MaxSpeed) + Math.PI/2);
			}else{
				direction = (float)(Math.Acos(Speed.X / MaxSpeed) + Math.PI);
			}
		}

		#region static

		public static Vector2 VectorSpeed(float  speed, float direction){
			return new Vector2((float)Math.Cos(direction) * speed, (float)Math.Sin(-direction) * speed);
		}

		public static float Direction(Vector2 speed) {
			float maxSpeed = speed.Length();
			if (speed.Y > 0){
				return (float)(Math.Asin(speed.X / maxSpeed) + Math.PI/2);
			}else{
				return (float)(Math.Acos(speed.X / maxSpeed) + Math.PI);
			}
		}

		public static float Distance(Vector2 positionA, Vector2 positionB){
			return (positionA - positionB).Length();
		}

		public static float Angle(Vector2 positionA, Vector2 positionB){
			return Direction(positionA - positionB);
		}

		public static Vector2 Follow(Vector2 positionA, Vector2 positionB, float maxDistance, float maxSpeed){
			if(Distance(positionA, positionB) > maxDistance && (positionB.X != positionA.X && positionB.Y != positionA.Y)){
				float dir = Angle(positionA, positionB);
				return VectorSpeed(maxSpeed, dir);
			}else{
				return Vector2.Zero;
			}
		}

		public static float TotalSpeed(Vector2 speed){
			return speed.Length();
		}

		#endregion
	}
}
