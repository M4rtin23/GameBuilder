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
		    sprBt.Draw(Sprite, new Vector2(rec.X, rec.Y),rec,color,0,new Vector2(0,0),new Vector2(rec.Width/128f, rec.Height/128f), SpriteEffects.None,0);
	    }
        public static void  DrawLine(SpriteBatch sprBt, Vector2 pos, Vector2 otherPos, float size, Color color){
            float s = (float)(CalculateDistance(pos, otherPos));
            float r = (float)(-CalculateAngle(pos, otherPos) * Math.PI/180);
            sprBt.Draw(Sprite, pos, null, color, r, new Vector2(0 ,0.5f), new Vector2(s, size), SpriteEffects.None, 0);
        }
        public static void DrawTriangle(SpriteBatch sprBt, Vector2 A, Vector2 B, Vector2 C){
//            Rectangle r = new Rectangle((int)A.X,(int) A.Y, 0, (int)CalculateDistance(A, B));
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
    }
}
