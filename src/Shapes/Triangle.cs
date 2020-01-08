using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static GameBuilder.Game1;

namespace GameBuilder{
    public class Triangle{
		Vector2[] vertices;
		Color color;
		int size;
		public Triangle(Vector2 a, Vector2 b, Vector2 c){
			vertices = new Vector2[]{a, b, c};
			color = Color.White;
			size = 2;
		}
		public Triangle(Vector2 a, Vector2 b, Vector2 c, int size, Color color){
			vertices = new Vector2[]{a, b, c};
			this.color = color;
			this.size = size;
		}

        public void Draw(SpriteBatch sprBt){
			for(int i = 0; i < 3; i++){
				new Line(vertices[i], vertices[i+1], size, color).Draw(sprBt);
			}
        }
    }
}
