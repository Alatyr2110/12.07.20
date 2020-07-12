using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Taranuha
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game()
        {
        }
        public static void Init(Form form)
        {           
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            Buffer.Render();

            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render(); 
        }
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }

        public static BaseObject[] _objs;
        public static void Load()
        {
            _objs = new BaseObject[60];//штук

            for (int i = 0; i < _objs.Length; i++)//!!!!!
                _objs[i] = new BaseObject(new Point(380, 280), new Point(-i/2,-i/3), new Size(5, 5));

            for (int i = _objs.Length / 5; i < 15; i++)
                _objs[i] = new Meteorit(new Point(780, 380), new Point(i*3, i*2),new Size(i, i));

            for (int i = _objs.Length / 3; i < _objs.Length; i++)
                _objs[i] = new Planet1(new Point(500, 50), new Point(1, 1), new Size(100, 100));

            for (int i = _objs.Length / 2; i < _objs.Length; i++)
                _objs[i] = new Planet(new Point(-100, -50), new Point(1, 2), new Size(130, 130));


        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
    }
}
