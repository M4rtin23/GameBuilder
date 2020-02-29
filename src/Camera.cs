using Microsoft.Xna.Framework;
using static GameBuilder.Game1;

namespace GameBuilder{
    public class Camera{
        public static Matrix Follow(Vector2 pos) {
            return Matrix.CreateTranslation(-pos.X,  -pos.Y, 0) * Matrix.CreateTranslation(Width/2, Height/2,0);
        }
		public static Matrix Follow(float x, float y, float scale){
            return Matrix.CreateTranslation(-x*scale,  -y*scale, 0) * Matrix.CreateTranslation(Width/2 , Height/2,0);
        }
    }
}
