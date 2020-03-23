using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static GameBuilder.Game1;

namespace GameBuilder{
	public class AI{
		Vector2 Position;
		float maxSpeed;
	
		public AI(Vector2 Position, float speed){
			this.Position = Position;
			this.maxSpeed = speed;
		}
		public float CalculateDistance(Vector2 position){
			return (Position - position).Length();
		}
		public float CalculateAngle(Vector2 position){
			return new Motion(Position - position).GetDirDegrees();
		}
		public Vector2 Follow(Vector2 position, float maxDistance){
			if(CalculateDistance(position) > maxDistance && (position.X != Position.X && position.Y != Position.Y)){
				float dir = (float) CalculateAngle(position);
				return new Motion(maxSpeed, dir).GetVectorSpeed();
			}else{
				return Vector2.Zero;
			}
		}
		public Vector2 Follow(Vector2 position){
			return Follow(position, 0);
		}
	}
}
