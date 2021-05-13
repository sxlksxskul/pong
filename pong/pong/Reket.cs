using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace pong
{
    class Reket
    {
        private int x;
        private int y;
        private int w, h;
        private int b;

        private Pen p;
        private SolidBrush sb;

        public Reket(int a, int b, int w, int h, int p, Pen olovka, SolidBrush cetka)
        {
            x = a;
            y = b;
            this.w = w;
            this.h = h;
            this.p = olovka;
            sb = cetka;
            this.b = p;
        }

        public void Resize(int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public int W
        {
            get { return w; }
        }

        public int H
        {
            get { return h; }
        }

        public int B
        {
            get { return b; }
        }

        public void nacrtaj_se(Graphics g)
        {
            g.FillRectangle(sb, x, y, w, h);
            g.DrawRectangle(p, x, y, w, h);
        }


        public bool sudar_bot(Lopta l)
        {
            if (l.X + l.R + l.DX >= x)
            {
                if(l.Y + l.R >= y && l.Y <= y + h)
                {
                    Debug.WriteLine(x);
                    Debug.WriteLine(y);
                    Debug.WriteLine(l.X);
                    Debug.WriteLine(l.Y);
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool sudar_igrac(Lopta l)
        {
            if (l.X + l.DX <= x + w)
            {
                if (l.Y >= y && l.Y <= y + h)
                {
                    Debug.WriteLine(x);
                    Debug.WriteLine(y);
                    Debug.WriteLine(l.X);
                    Debug.WriteLine(l.Y);
                    return true;
                }

                return false;
            }

            return false;
        }

        public void pomeri_se(int a)
        {
            y += 10 * a;
        }

        public void pocetna_pozicija(int a, int b)
        {
            x = a;
            y = b;
        }
    }
}
