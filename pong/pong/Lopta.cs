using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace pong
{
    class Lopta
    {
        private int x;
        private int y;
        private int r;
        private bool poslednji;
        private int n;

        private Pen p;
        private SolidBrush sb;

        private int dx;
        private int dy;

        public Lopta(int a, int b, int r, Pen olovka, SolidBrush cetka, int n)
        {
            x = a;
            y = b;
            this.r = r;
            dx = dy = 10;
            this.n = n;

            p = olovka;
            sb = cetka;

            if (this.n % 2 == 0)
            {
                poslednji = false;
            }
            else
            {
                poslednji = true;
                dx = -dx;
            }
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public int R
        {
            get { return r * 2; }
        }

        public int Malo_r
        {
            get { return r; }
        }

        public bool Poslednji
        {
            get { return poslednji; }
        }

        public int DX
        {
            get { return dx; }
        }

        public void pocetna_brzina()
        {
            dx = dy = 10;
        }

        public void nacrtaj_se(Graphics g)
        {
            g.FillEllipse(sb, x, y, r * 2, r * 2);
            g.DrawEllipse(p, x, y, r * 2, r * 2);
        }

        public void poslednji_udario_promena()
        {
            poslednji = !poslednji;
        }

        public void pomeri_se()
        {
            x += dx;
            y += dy;
        }

        public void ubrzaj_se()
        {
            dx += 2;
            dy++;
        }

        public int ivica_provera_x(int a)
        {
            if(x + r * 2 >= a || x + r * 2 + dx > a)
            {
                return 0;
            }
            else if(x == 0 || x + dx < 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public bool ivica_provera_y(int b)
        {
            if(y == 0 || y + dy < 0 || y + r * 2 == b || y + r * 2 + dy > b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ivica_y()
        {
            dy = -dy;
        }

        public void odbij_se()
        {
            dx = -dx;
        }

        public void vrati_se(int a, int b)
        {
            x = a;
            y = b;
        }

        public void stani()
        {
            dx = 0;
            dy = 0;
        }

    }
}
