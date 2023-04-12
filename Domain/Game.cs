using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Domain
{
    public class Player
    {
        public (int X, int Y) position;
        public Image sprite;

        public (int X, int Y) direction;
        //public int dirX;
        //public int dirY;

        public int speed;
        public bool isMoving;

        public int currentAnimation;
        public int currentFrame;

        //public int forwardFrames;
        //public int backFrames;
        //public int leftFrames;
        //public int rightFrames;

        public int currentLimit;

        public static (int X, int Y) size;

        public Player((int, int) position/*, int forwardFrames, int backFrames, int leftFrames, int rightFrames*/, Image sprite)
        {
            this.position = position;

            //this.forwardFrames = forwardFrames;
            //this.backFrames = backFrames;
            //this.leftFrames = leftFrames;
            //this.rightFrames = rightFrames;
            this.sprite = sprite;
            size = (317, 340);
            speed = 10;
            currentAnimation = 4;
            currentFrame = 0;
            currentLimit = 4;
        }

        public void Move()
        {
            position.X += direction.X;
            position.Y += direction.Y;

            //posX += dirX;
            //posY += dirY;
        }

        public void PlayAnimation(Graphics g)
        {
            if (currentFrame < currentLimit - 1)
                currentFrame++;
            else currentFrame = 0;
            //g.DrawImage(sprite, 10, 10, new Rectangle(new Point(size.X * currentFrame, size.Y*currentAnimation), new Size(size.X, size.Y)), /*2*currentFrame, 32*currentAnimation, size, size*/ GraphicsUnit.Pixel);
            g.DrawImage(sprite, new Rectangle(new Point(position.X, position.Y), new Size(size.X/4, size.Y/4)), size.X * currentFrame, size.Y * currentAnimation, size.X, size.Y, GraphicsUnit.Pixel);
        }

        public void SetAnimationConfiguration(int currentAnimation)
        {
            this.currentAnimation = currentAnimation;

            //switch (currentAnimation)
            //{
            //    case 0:
            //        currentLimit = forwardFrames;
            //        break;
            //    case 1:
            //        currentLimit = backFrames;
            //        break;
            //    case 2:
            //        currentLimit = leftFrames;
            //        break;
            //    case 3:
            //        currentLimit = rightFrames;
            //        break;
            //    case 4:
            //        currentLimit = 4;
            //        break;
            //}
        }

    }

    class Block
    {

    }

    class Weapon
    {

    }

    class Enemy
    {

    }

    class Coin
    {

    }

    class Health
    {

    }
}
