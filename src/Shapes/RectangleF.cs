using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static GameBuilder.Game1;
using static GameBuilder.Physics;

namespace GameBuilder{
    public class RectangleF{
		Rectangle rectangle;
		Color color;
	    public RectangleF(Rectangle rectangle){
			this.rectangle = rectangle;
			color = Color.White;
		}
		public RectangleF(Rectangle rectangle, Color color){
			this.rectangle = rectangle;
			this.color = color;
		}
		
		public void Draw(SpriteBatch sprBt){
		    sprBt.Draw(Sprite, rectangle.Location.ToVector2(), null, color, 0, new Vector2(0, 0), rectangle.Size.ToVector2(), SpriteEffects.None, 0.9f);
	    }
    }
}
