using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;



namespace Taranuha
{
    class Planet1 : BaseObject
    {
        public Planet1(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.Green, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
       public override void Update()
        {
            Pos.X = Pos.X;
            Pos.Y = Pos.Y;
        }
    }
}