using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static GameBuilder.Game1;
using static GameBuilder.Builder;

namespace GameBuilder{
    public class Line{
		Vector2[] points;
		Color color;
		int size;
		public Line(Vector2 a, Vector2 b){
			points = new Vector2[]{a, b};
			color = Color.White;
			size = 4;
		}
		public Line(Vector2 a, Vector2 b, int size, Color color){
			points = new Vector2[]{a, b};
			color = this.color;
			size = this.size;
		}

        public void Draw(SpriteBatch sprBt){
            float lenght = (float)(CalculateDistance(points[0], points[1]));
            float rotation = (float)(-CalculateAngle(points[0], points[1]) * Math.PI/180);
            sprBt.Draw(Sprite, points[0], null, color, rotation, new Vector2(0 ,0.5f), new Vector2(lenght, size), SpriteEffects.None, 0);
        }
    }
}
