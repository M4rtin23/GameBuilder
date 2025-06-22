using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static GameBuilder.GameType.FixedView;
using GameBuilder.Shapes;
namespace GameBuilder.InGame{
	public class ObjectBuilder{
		public Vector2 Position;
		protected Vector2 speed, acceleration, scale = Vector2.One;
		protected Vector2 origin{get => new Vector2(SpriteIndex.Width/(2*frames), SpriteIndex.Height/2);}
		public Texture2D SpriteIndex;
		public RectangleF Hitbox = new RectangleF();
		public RectangleF FastHitbox {get => new RectangleF(Position - origin*scale, rectangle.Size * scale);}
		protected RectangleF rectangle{get=> new RectangleF((int)imageIndex*SpriteIndex.Width/frames, 0, SpriteIndex.Width/frames, SpriteIndex.Height);}
		protected float imageIndex, animationSpeed;
		protected SpriteEffects effect = SpriteEffects.None;
		protected float rot = 0, maxSpeed;
		protected Color color = Color.White;
		private float depth;
		protected int frames = 4;
		protected int alpha = 255;

		public ObjectBuilder(){
			SpriteIndex = Shape.DefaultTexture;
		}
		public ObjectBuilder(Texture2D texture, Vector2 position){
			SpriteIndex = texture;
			Position = position;
		}

		public virtual void Update(){
			if(!double.IsNaN(speed.X) && !double.IsNaN(speed.Y)){
				Position += speed += acceleration;
			}
			imageIndex += animationSpeed;
			imageIndex = imageIndex % frames;
		}

		public virtual void Draw(SpriteBatch batch){
			depth = (-Position.Y / (MapLimit+1)) + 0.5f;
			batch.Draw(SpriteIndex, Position, rectangle.ToRectangle(), new Color(alpha*2-color.R ,alpha*2-color.G, alpha*2-color.B, alpha*2-255), rot, origin, scale, effect, depth);
		}

		protected bool PreCollision(RectangleF rec){
			return new RectangleF(Hitbox.Location + (speed*2), Hitbox.Size).Intersects(rec);
		}

		protected bool PreCollisionX(RectangleF rec){
			RectangleF r = new RectangleF(Hitbox.Location, Hitbox.Size);
			r.X += speed.X;
			return r.Intersects(rec);
		}

		protected bool PreCollisionY(RectangleF rec){
			RectangleF r = new RectangleF(Hitbox.Location, Hitbox.Size);
			r.Y += speed.Y;
			return r.Intersects(rec);
		}

		protected void userCollision(ObjectBuilder[] entities){
			for(int i = 0; i<entities.Length; i++){
				if(entities[i] != null && entities[i].Position != Position){
					if(PreCollisionX(entities[i].Hitbox)){
						speed.X = 0;
					}
					if(PreCollisionY(entities[i].Hitbox)){
						speed.Y = 0;
					}
				}
			}
		}

		protected void entityCollision0(ObjectBuilder[] entities){
			for(int i = 0; i < entities.Length; i++){
				if(entities[i] != null && entities[i].Position != Position){
					if(PreCollision(new RectangleF(entities[i].Hitbox.Location+speed,entities[i].Hitbox.Size))){
						Motion a = new Motion(speed);
						a.Degrees += 90*((2*System.Convert.ToInt16(a.Radians < Motion.Angle(Position, entities[i].Position)))-1);
						System.Console.WriteLine(a.Radians > Motion.Angle(Position, entities[i].Position));
						speed = a.Speed;
					}
				}
			}
			entityCollision0(entities);
		}

		protected void entityCollision(ObjectBuilder[] entities){
			for(int i = 0; i < entities.Length; i++){
				if(entities[i] != null && entities[i].Position != Position){
					if(PreCollisionX(entities[i].Hitbox)){
						speed.X = 0;
					}
					if(PreCollisionY(entities[i].Hitbox)){
						speed.Y = 0;
					}
				}
			}
		}
		public static int GetClosest(ObjectBuilder[] entities, Vector2 position){
			float shortestDistance = -1;
			int targetDefiner = -1;
			for (int i = 0; i < entities.Length; i++) {
				if (entities[i] != null) {
					int enemyDistance = (int)Motion.Distance(entities[i].Position, position);
					if (shortestDistance == -1 || enemyDistance <= shortestDistance){
						shortestDistance = enemyDistance;
						targetDefiner = i;
					}
				}
			}
			return targetDefiner;
		}
	}
}
