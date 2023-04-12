using MyGame.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public static class MapController
    {
        public static int cellSize { get; set; }
        public static int height;
        public static int width;
        public static Image grassSprite;
        public static Image treeSprite;
        public static int[,] map;

        public static void Initialize()
        {
            grassSprite = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Sprites\\Grass2.png"));
            treeSprite = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Sprites\\Tree.png"));
            cellSize = 40;
            map = new int[,]
            {
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 },
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 },
                { 0 , 0 , 1 , 0 , 0 , 0 , 0 },
                { 0 , 0 , 0 , 1 , 0 , 0 , 0 },
                { 0 , 0 , 0 , 0 , 1 , 0 , 0 },
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 },
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 },
            };
        }

        public static void CreateMap(Graphics g)
        {
            for (var i = 0; i < map.GetLength(0); i++)
            {
                for (var j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 0)
                    {
                        g.DrawImage(grassSprite, new Rectangle(new Point(i * cellSize, j * cellSize), new Size(cellSize, cellSize)), 0, 0, grassSprite.Width, grassSprite.Height, GraphicsUnit.Pixel);
                    }
                }
            }
        }

        public static void CreateMapEntities(Graphics g)
        {
            for (var i = 0; i < map.GetLength(0); i++)
            {
                for (var j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 1)
                    {
                        g.DrawImage(treeSprite, new Rectangle(new Point(i * cellSize, j * cellSize), new Size(cellSize, cellSize)), 0, 0, treeSprite.Width, treeSprite.Height, GraphicsUnit.Pixel);
                    }
                }
            }
        }
    }
}
