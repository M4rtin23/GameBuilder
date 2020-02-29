using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static GameBuilder.Game1;

namespace GameBuilder{
	public class Builder{
		public static double CalculateVspeed(float speed,float direction) {
			return Math.Sin(-direction*Math.PI/180) * speed;
		}
		public static double CalculateHspeed(float speed, float direction){
			return Math.Cos(direction*Math.PI/180) * speed;
		}
		public static Vector2 CalculateVectorSpeed(float speed, float direction){
			return new Vector2((float) CalculateHspeed(speed, direction),(float) CalculateVspeed(speed, direction));
		}
		public static double CalculateDirection(float Hspeed,float Vspeed) {
			if (Vspeed > 0){
				return (Math.Asin(Hspeed / CalculateSpeed(Hspeed, Vspeed)) / Math.PI * 180) + 90;
			}else{
				return (Math.Acos(Hspeed / CalculateSpeed(Hspeed, Vspeed)) / Math.PI * 180) + 180;
			}
		}
		public static double CalculateSpeed(float Hspeed, float Vspeed) {
			return Math.Sqrt(Vspeed*Vspeed + Hspeed*Hspeed);
		}
		public static float CalculateDistance(Vector2 ObjA, Vector2 ObjB){
			return (int) (CalculateSpeed(ObjA.X - ObjB.X, ObjA.Y - ObjB.Y));
		}
		public static double CalculateAngle(Vector2 ObjA, Vector2 ObjB){
			return CalculateDirection(ObjA.X - ObjB.X, ObjA.Y - ObjB.Y);
		}

		public static void DrawRectangle(SpriteBatch sprBt, Rectangle rec, Color color){
			sprBt.Draw(Sprite, new Vector2(rec.X, rec.Y), null, color, 0, new Vector2(0, 0), new Vector2(rec.Width, rec.Height), SpriteEffects.None, 0.9f);
		}
		public static void DrawRectangle(SpriteBatch sprBt, Vector2 pos, Color color){
			sprBt.Draw(Sprite, pos, null, color, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0.9f);
		}

		public static void  DrawLine(SpriteBatch sprBt, Vector2 pos, Vector2 otherPos, float size, Color color){
			float s = (float)(CalculateDistance(pos, otherPos));
			float r = (float)(-CalculateAngle(pos, otherPos) * Math.PI/180);
			sprBt.Draw(Sprite, pos, null, color, r, new Vector2(0 ,0.5f), new Vector2(s, size), SpriteEffects.None, 0);
		}
		public static void DrawTriangle(SpriteBatch sprBt, Vector2 A, Vector2 B, Vector2 C){
			DrawLine(sprBt, A, B, 2, Color.White);
			DrawLine(sprBt, A, C, 2, Color.White);
			DrawLine(sprBt, B, C, 2, Color.White);
		}
		public static float SqrCos(float angle){
			angle = angle % ((float)Math.PI*2) - (float)Math.PI;
			angle = Math.Abs(angle)*2/(float)Math.PI-1;
			return angle;
		}
		 public static float SqrSin(float angle){
			angle = (angle+(float)Math.PI/2) % ((float)Math.PI*2) - (float)Math.PI;
			angle = Math.Abs(angle)*2/(float)Math.PI-1;
			return angle;
		}
		public static Vector2 Follow(Vector2 followerPos, Vector2 position, float hitboxSize, float maxSpeed){
			if(CalculateDistance(position, followerPos) > hitboxSize && (position.X != followerPos.X && position.Y != followerPos.Y)){
				float dir = (float) CalculateAngle(position, followerPos);
				Vector2 spd = new Vector2();
				if(position.X != followerPos.X){
					spd.X = (float)CalculateHspeed(maxSpeed, dir);
				}
				else{
					spd.X = 0;
				}
				if(position.Y != followerPos.Y){
					spd.Y = (float)CalculateVspeed(maxSpeed, dir);
				}else{
					spd.Y = 0;
				}
				return spd;
			}else{
				return Vector2.Zero;
			}
		}
		public static bool IsCollision(Rectangle hitbox, Rectangle other, Vector2 speed){
			return new Rectangle(hitbox.X+(int)speed.X, hitbox.Y+(int)speed.Y, hitbox.Width, hitbox.Height).Intersects(other);
		}
		public static bool IsCollisionX(Rectangle hitbox, Rectangle other, Vector2 speed){
			return new Rectangle(hitbox.X+(int)speed.X, hitbox.Y, hitbox.Width, hitbox.Height).Intersects(other);
		}
		public static bool IsCollisionY(Rectangle hitbox, Rectangle other, Vector2 speed){
			return new Rectangle(hitbox.X, hitbox.Y+(int)speed.Y, hitbox.Width, hitbox.Height).Intersects(other);
		}
	}
}
