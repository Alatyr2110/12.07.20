using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Taranuha
{
    class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }
        public virtual void Draw() 
        {
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
        }
        public virtual void Update()
        {

            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;

            if (Pos.X < 0)
            {
                Pos.X = 380;
                Pos.Y = 280;
                Dir.X = -Dir.X;
                Dir.Y = -Dir.Y;
            }

            if (Pos.X > Game.Width)
            {
                Pos.X = 380;
                Pos.Y = 280;
                Dir.X = -Dir.X;
                Dir.Y = Dir.Y;
            }

            if (Pos.Y < 0)
            {
                Pos.X = 380;
                Pos.Y = 280;
                Dir.X = Dir.X;
                Dir.Y = -Dir.Y;
            }

            if (Pos.Y > Game.Height)
            {
                Pos.X = 380;
                Pos.Y = 280;
                Dir.X = Dir.X;
                Dir.Y = Dir.Y;
            }
        }
                
    }
}
