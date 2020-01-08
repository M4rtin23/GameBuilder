using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static GameBuilder.Game1;
using static GameBuilder.Physics;

namespace GameBuilder{
    public class Point{
		Vector2 position;
		Color color;
		int size;
		public Point(Vector2 position){
			this.position = position;
			color = Color.White;
			size = 1;
		}
		public Point(Vector2 position, int size, Color color){
			this.position = position;
			this.color = color;
			this.size = size;
		}
		public void Draw(SpriteBatch sprBt){
		    sprBt.Draw(Sprite, position, null, color, 0, new Vector2(0.5f, 0.5f), size, SpriteEffects.None, 0.9f);
		}
    }
}
