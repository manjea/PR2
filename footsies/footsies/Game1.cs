using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;

namespace footsies
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D backgroundTexture;
        private Texture2D layer1Texture;
        private Texture2D layer2Texture;
        private Texture2D layer3Texture;
        private ParallaxTexture layer1;
        private ParallaxTexture layer2;
        private ParallaxTexture layer3;

        private Texture2D normalTexture;
        private Texture2D jumpingTexture;
        private Texture2D crouchTexture;
        private Texture2D fireballTexture;
        private Texture2D currentTexture;

        private SpriteFont font;

        private List<Vector2> fireballs;
        private int fireballTimer = 120;
        private Random prng;
        private double score = 0;


        private Vector2 position;
        private Vector2 speed;

        private bool isJumping;
        private bool isCrouching;
        private bool hit;
        private bool isPlaying;

        private const int START_Y = 420;

        Song song;

        List<SoundEffect> soundEffects;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
            soundEffects = new List<SoundEffect>();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            position = new Vector2(300, START_Y);
            fireballs = new List<Vector2>();
            prng = new Random();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            backgroundTexture = Content.Load<Texture2D>("background");
            layer1Texture = Content.Load<Texture2D>("layer1");
            layer2Texture = Content.Load<Texture2D>("layer2");
            layer3Texture = Content.Load<Texture2D>("layer3");
            layer1 = new ParallaxTexture(layer1Texture, 370);
            layer2 = new ParallaxTexture(layer2Texture, 300);
            layer3 = new ParallaxTexture(layer3Texture, 180);

            /*song = Content.Load<Song>("prepare");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;*/


            soundEffects.Add(Content.Load<SoundEffect>("jumpSnd"));
            soundEffects.Add(Content.Load<SoundEffect>("jumpSnd2"));
            soundEffects.Add(Content.Load<SoundEffect>("hitSnd"));

            font = Content.Load<SpriteFont>("font");

            normalTexture = Content.Load<Texture2D>("normal");
            jumpingTexture = Content.Load<Texture2D>("jump");
            crouchTexture = Content.Load<Texture2D>("crouch");
            fireballTexture = Content.Load<Texture2D>("fireball");

        }

        void MediaPlayer_MediaStateChanged(object sender, System.EventArgs e)
        {
            // 0.0f is silent, 1.0f is full volume
            MediaPlayer.Volume -= 0.1f;
            MediaPlayer.Play(song);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState state = Keyboard.GetState();


            if (!isPlaying)
            {
                if (state.IsKeyDown(Keys.Enter))
                {
                    Reset();
                    isPlaying = true;
                }
                if (!isPlaying)
                    return;
            }

            //parallax layers
            layer1.offsetX += 1.5f;
            layer2.offsetX += 1f;
            layer3.offsetX += 0.5f;

            score += gameTime.ElapsedGameTime.TotalSeconds;

            position += speed;
            if(position.Y > START_Y)
            {
                position.Y = START_Y;
                speed = Vector2.Zero;
                isJumping = false;
            }
            speed += new Vector2(0, 0.1f);

            if (state.IsKeyDown(Keys.W) && !isJumping)
            {
                speed = new Vector2(0, -2f);
                soundEffects[prng.Next(0,2)].Play();
                isJumping = true;
            }
            if (state.IsKeyDown(Keys.S) && !isJumping)
                isCrouching = true;
            else
                isCrouching = false;

            //fireballs
            fireballTimer--;
            if(fireballTimer <= 0)
            {
                fireballTimer = 120;

                if (prng.Next(2) == 0)
                    fireballs.Add(new Vector2(800, START_Y));
                else
                    fireballs.Add(new Vector2(800, START_Y + 40));
            }

            for(int i = 0; i < fireballs.Count; i++)
                fireballs[i] = fireballs[i] + new Vector2(-2, 0);


            //collision

            if(isJumping)
            {
                currentTexture = jumpingTexture;
            }
            else if(isCrouching)
            {
                currentTexture = crouchTexture;
            }
            else
            {
                currentTexture = normalTexture;
            }


            
            Rectangle playerBox = new Rectangle((int)position.X, (int)position.Y, 
                currentTexture.Width, currentTexture.Height);

            hit = false;
            foreach (Vector2 fireball in fireballs)
            {
                Rectangle fireballBox = new Rectangle((int)fireball.X, (int)fireball.Y, 
                    fireballTexture.Width, fireballTexture.Height);

                //överlappar vi?
                Rectangle collision = Intersection(playerBox, fireballBox);

                if (collision.Width > 0 && collision.Height > 0)
                {
                    Rectangle r1 = Normalize(playerBox, collision);
                    Rectangle r2 = Normalize(fireballBox, collision);
                    hit = TestCollision(currentTexture, r1, fireballTexture, r2);
                    if (hit)
                    {
                        soundEffects[1].Play();
                        isPlaying = false;

                    }
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            
            _spriteBatch.Begin();

            _spriteBatch.Draw(backgroundTexture, new Vector2(-100, -100), Color.White);

            //parallax effekt
            layer3.Draw(_spriteBatch);
            layer2.Draw(_spriteBatch);
            layer1.Draw(_spriteBatch);
            
            

            if (isPlaying)
            {
                _spriteBatch.DrawString(font, $"Tid: {score:F2}", new Vector2(10, 20), Color.White);

                _spriteBatch.Draw(currentTexture, position, Color.White);

                foreach (Vector2 fireball in fireballs)
                    _spriteBatch.Draw(fireballTexture, fireball, Color.White);

                if (hit)
                    _spriteBatch.DrawString(font, "hit!", 
                        new Vector2(10, 40), Color.White);
            }
            else
            {
                _spriteBatch.DrawString(font, "Press Enter to start!", new Vector2(GraphicsDevice.Viewport.Width/2-72, GraphicsDevice.Viewport.Height/2), Color.Black);
                _spriteBatch.DrawString(font, $"score -> {score:F2}", new Vector2(GraphicsDevice.Viewport.Width/2-50, GraphicsDevice.Viewport.Height/2+40), Color.Black);

            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void Reset()
        {
            fireballs.Clear();
            fireballTimer = 120;
            score = 0;
        }

        #region - Metoder som ingen bryr sig om -
        public static Rectangle Intersection(Rectangle r1, Rectangle r2)
        {
            int x1 = Math.Max(r1.Left, r2.Left);
            int y1 = Math.Max(r1.Top, r2.Top);
            int x2 = Math.Min(r1.Right, r2.Right);
            int y2 = Math.Min(r1.Bottom, r2.Bottom);

            if((x2 >= x1) && (y2 >= y1))
            {
                return new Rectangle(x1, y1, x2 - x1, y2 - y1);
            }
            return Rectangle.Empty;
        }
        public static Rectangle Normalize(Rectangle reference, Rectangle overlap)
        {
            return new Rectangle(
                overlap.X - reference.X,
                overlap.Y - reference.Y,
                overlap.Width,
                overlap.Height);
        }
        public static bool TestCollision(Texture2D t1, Rectangle r1, Texture2D t2, Rectangle r2)
        {
            int pixelCount = r1.Width * r1.Height;
            uint[] texture1Pixels = new uint[pixelCount];
            uint[] texture2Pixels = new uint[pixelCount];

            t1.GetData(0, r1, texture1Pixels, 0, pixelCount);
            t2.GetData(0, r2, texture2Pixels, 0, pixelCount);

            for (int i = 0; i < pixelCount; ++i)
            {
                if (((texture1Pixels[i] & 0xff000000) > 0) && ((texture2Pixels[i] & 0xff000000) > 0))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
