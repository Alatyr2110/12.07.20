using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Taranuha
{
    class Meteorit : BaseObject
    {
        public Meteorit(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.Red, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            Pos.Y = Pos.Y - Dir.Y;

                   if (Pos.X < -5)
                   {
                       Pos.X = 780;
                       Pos.Y = 380;
                   }

                   if (Pos.Y < -5)
                   {
                       Pos.X = 380;
                       Pos.Y = 580;
                   }
        }
    }
}
