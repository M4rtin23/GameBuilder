using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static GameBuilder.GameType.FixedView;
using GameBuilder.Shapes;
namespace GameBuilder.InGame{
	public class ObjectBuilder{
		public Vector2 Position;
		protected Vector2 speed, acceleration, origin, scale = Vector2.One;
		public Texture2D SpriteIndex;
		public RectangleF Hitbox = new RectangleF();
		public RectangleF FastHitbox {get => new RectangleF(Position - origin*scale, rectangle.Size * scale);}
		protected RectangleF rectangle = new RectangleF();
		protected float imageIndex, animationSpeed;
		protected SpriteEffects effect = SpriteEffects.None;
		protected float rot = 0, maxSpeed;
		protected Color color = Color.White;
		private float depth;
		protected int alpha = 255;

		public ObjectBuilder(){
			SpriteIndex = Shape.DefaultTexture;
		}
		public ObjectBuilder(Texture2D texture, Vector2 position, RectangleF rectangle, Vector2 origin){
			SpriteIndex = texture;
			Position = position;
			this.rectangle = rectangle;
			this.origin = origin;
		}

		public virtual void Update(){
			if(!double.IsNaN(speed.X) && !double.IsNaN(speed.Y)){
				Position += speed += acceleration;
			}
		}

		public virtual void Draw(SpriteBatch batch){
			depth = (-Position.Y / (MapLimit+1)) + 0.5f;
			batch.Draw(SpriteIndex, Position, rectangle.ToRectangle(), new Color(alpha*2-color.R ,alpha*2-color.G, alpha*2-color.B, alpha*2-255), rot, origin, scale, effect, depth);
		}

		protected virtual void animationImage(int frameNumb){
			imageIndex += animationSpeed;
			imageIndex = imageIndex % frameNumb;
		}

		protected virtual void center(int frameNumb){
			origin = new Vector2(SpriteIndex.Width/(2*frameNumb), SpriteIndex.Height/2);
		}

		protected virtual void stripSprite(int frameNumb){
			rectangle = new RectangleF((int)imageIndex*SpriteIndex.Width/frameNumb, 0, SpriteIndex.Width/frameNumb, SpriteIndex.Height);
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
	}
}
