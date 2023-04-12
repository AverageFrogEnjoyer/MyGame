using MyGame.Domain;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System;
using System.Security.Policy;

namespace MyGame
{
    public partial class Form1 : Form
    {
        public Image playerSprite;
        
        public int cellSize;
        public Player player;
        public int[,] map;
        
        public Form1()
        {
            InitializeComponent();

            timer1.Interval = 70;
            timer1.Tick += new EventHandler(Update);

            KeyDown += new KeyEventHandler(OnKeyDown);
            KeyUp += new KeyEventHandler(OnKeyUp);

            Initialize();
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.direction.Y = 0;
                    break;
                case Keys.S:
                    player.direction.Y = 0;
                    break;
                case Keys.A:
                    player.direction.X = 0;
                    break;
                case Keys.D:
                    player.direction.X = 0;
                    break;
            }
            if (player.direction.X == 0 && player.direction.Y == 0)
            {
                player.isMoving = false;
                player.SetAnimationConfiguration(4);

            }
            
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.direction.Y = -player.speed;
                    player.SetAnimationConfiguration(3);
                    break;
                case Keys.S:
                    player.direction.Y = player.speed;
                    player.SetAnimationConfiguration(0);
                    break;
                case Keys.A:
                    player.direction.X = -player.speed;
                    player.SetAnimationConfiguration(1);
                    break;
                case Keys.D:
                    player.direction.X = player.speed;
                    player.SetAnimationConfiguration(2);
                    break;
            }
            player.isMoving = true;

        }

        public void Update(object sender, EventArgs e)
        {
            if (player.isMoving)
                player.Move();
            Invalidate();
        }

        public void Initialize()
        {
            MapController.Initialize();
            
            var position = (100, 100);
            playerSprite = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Sprites\\Player.png"));
            

            player = new Player(position,/* PlayerModel.Model.forwardFrames, PlayerModel.Model.backFrames, PlayerModel.Model.leftFrames, PlayerModel.Model.rightFrames,*/ playerSprite);
            timer1.Start();

            

        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            MapController.CreateMap(g);
            MapController.CreateMapEntities(g);
            player.PlayAnimation(g);
            
        }

        
    }
}
