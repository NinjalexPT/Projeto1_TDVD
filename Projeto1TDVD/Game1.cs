using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace Projeto1TDVD
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont font;
        private int nrLinhas = 0;
        private int nrColunas = 0;
        private char[,] Level;
        private Texture2D player, dot, box, wall;
        int tileSize = 64;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            LoadLevel("level1.txt");

            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Fonte");
            player = Content.Load<Texture2D>("Character6");
            dot = Content.Load<Texture2D>("EndPoint_Black");
            box = Content.Load<Texture2D>("Crate_Blue");
            wall = Content.Load<Texture2D>("Wall_Gray");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            
            //_spriteBatch.DrawString(font, "This is some trully some amazing text right here", new Vector2(100, 100), Color.Gold);
            //_spriteBatch.DrawString(font, $"Numero de linhas = {nrLinhas} -- Numero de Colunas = {nrColunas}", new Vector2(0,0), Color.Black);
            Rectangle position = new Rectangle(0,0,tileSize,tileSize);

            for(int x = 0; x < Level.GetLength(0); x++)
            {
                for(int y = 0; y < Level.GetLength(1); y++)
                {
                    position.X = x * tileSize;
                    position.Y = y * tileSize;

                    switch(Level[x, y])
                    {
                        case 'Y':
                            _spriteBatch.Draw(player, position, Color.White);
                            break;
                        case 'X':
                            _spriteBatch.Draw(wall, position, Color.White);
                            break;
                        case '#':
                            _spriteBatch.Draw(box, position, Color.White);
                            break;
                        case '.':
                            _spriteBatch.Draw(dot, position, Color.White);
                            break;
                    }
                }
            }
            
            _spriteBatch.End();


            base.Draw(gameTime);
        }

        void LoadLevel(string levelFile)
        {
            string[] linhas = File.ReadAllLines($"Content/{levelFile}");
            nrLinhas = linhas.Length;
            nrColunas = linhas[0].Length;

            Level = new char[nrColunas,nrLinhas];

            for(int x = 0; x < nrColunas; x++)
            {
                for(int y = 0; y < nrLinhas; y++)
                {
                    Level[x,y] = linhas[y][x];
                }
            }
            
        }

    }
}
