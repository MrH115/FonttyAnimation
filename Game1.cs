using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FonttyAnimation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Texture2D sheet1;
        public Texture2D sheet2;
        public Texture2D sheet3;
        public Animation animation;
        public Vector2 position = new Vector2(75, 75);
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            sheet1 = Content.Load<Texture2D>("MiniReaper");
            sheet2 = Content.Load<Texture2D>("MiniZombie");
            sheet3 = Content.Load<Texture2D>("MiniPrinceMan");
            animation = new Animation(sheet3, 32, 32, 0, 32, 5, 0.3f, position, true, true);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            animation.Update(gameTime);
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                animation.isFliped = false;
                animation.position.X += 0.3f;
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                animation.position.X -= 0.3f;
                animation.isFliped = true;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DeepSkyBlue);
            _spriteBatch.Begin(SpriteSortMode.Immediate, null, SamplerState.PointClamp, null, null, null, Matrix.CreateScale(3f));
            animation.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
