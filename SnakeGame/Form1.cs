using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        private List<Circle> Snake = new List<Circle>;
        private Circle food = new Circle();
        public Form1()
        {
            InitializeComponent();

            // Set settings to default
            new Settings();

            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Tick += UpdateScreen();
            gameTimer.Start();

            // Start a new game
            StartGame();
        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            // Check for game over
            if (Settings.GameOver == true)
            {
                //Check if enter is pressed 
                if (Input.KeyPressed(Keys.Enter))
                {
                    StartGame();
                }
                else
                {
                    if (Input.KeyPressed(Keys.Right) && Settings.direction != Direction.Left)
                        Settings.direction = Direction.Right;
                    else if (Input.KeyPressed(Keys.Left) && Settings.direction != Direction.Right)
                        Settings.direction = Direction.Left;
                    else if (Input.KeyPressed(Keys.Up) && Settings.direction != Direction.Down)
                        Settings.direction = Direction.Up;
                    else if (Input.KeyPressed(Keys.Down) && Settings.direction != Direction.Up)
                        Settings.direction = Direction.Down;

                    MovePlayer();
                }

                pbCanvas.Invalidate();
            }
        }

        private void StartGame()
        {
            // Set settings to default 
            new Settings();

            Circle head = new Circle();

            head.X = 10;
            head.Y = 5;
            Snake.Add(head);

            lblScore.Text = Settings.Score.ToString();
            GenerateFood();
        }

        //Place random food object
        private void GenerateFood()
        {
            int maxXPos = pbCanvas.Size.Width / Settings.Width;
            int maxYPos = pbCanvas.Size.Height / Settings.Height;

            Random random = new Random();
            food = new Circle();
            food.X = random.Next(0, maxXPos);
            food.Y = random.Next(0, maxYPos);
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
