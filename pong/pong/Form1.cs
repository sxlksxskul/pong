using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pong
{
    public partial class Form1 : Form
    {
        Reket igrac, bot;
        Lopta l;
        Pen p = new Pen(Color.Black);
        SolidBrush sb = new SolidBrush(Color.Black);
        Pen p1 = new Pen(Color.Red);
        SolidBrush sb1 = new SolidBrush(Color.Blue);
        Random r = new Random();
        int r1;
        int b1 = 0;
        int i1 = 0;
        Lopta lopta_druga;
        int opcija;

        public void resetuj_igricu()
        {
            b1 = i1 = 0;
            label1.Text = "0";
            label2.Text = "0";
            l.vrati_se(ClientRectangle.Width / 2, ClientRectangle.Height / 2);
            lopta_druga.vrati_se(ClientRectangle.Width / 2, ClientRectangle.Height / 2);
            igrac.pocetna_pozicija(5, ClientRectangle.Height / 2 - 8);
            bot.pocetna_pozicija(ClientRectangle.Width - 10, ClientRectangle.Height / 2 - 8);
            upis_opcije.Visible = true;
            timer2.Start();
            timer1.Stop();
        }

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            igrac = new Reket(5, ClientRectangle.Height / 2 - 8, 5, 100, 1, p, sb);
            bot = new Reket(ClientRectangle.Width - 10, ClientRectangle.Height / 2 - 8, 5, 100, 0, p, sb);
            r1 = r.Next(51);
            l = new Lopta(ClientRectangle.Width / 2, ClientRectangle.Height / 2, 5, p1, sb1, r1);
            r1 = l.DX;
            lopta_druga = new Lopta(ClientRectangle.Width / 2, ClientRectangle.Height / 2, 5, p1, sb1, -r1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            igrac.nacrtaj_se(e.Graphics);
            bot.nacrtaj_se(e.Graphics);
            l.nacrtaj_se(e.Graphics);
            lopta_druga.nacrtaj_se(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.W)
            {
                igrac.pomeri_se(-1);
                Refresh();
            }

            if(e.KeyCode == Keys.S)
            {
                igrac.pomeri_se(1);
                Refresh();
            }

            if(opcija == 2)
            {
                if(e.KeyCode == Keys.Up)
                {
                    bot.pomeri_se(-1);
                    Refresh();
                }

                if(e.KeyCode == Keys.Down)
                {
                    bot.pomeri_se(1);
                    Refresh();
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(upis_opcije.Text == "1")
            {
                opcija = 1;
                upis_opcije.Clear();
                upis_opcije.Visible = false;
                timer1.Start();
                timer2.Stop();
            }
            else if(upis_opcije.Text == "2")
            {
                opcija = 2;
                upis_opcije.Clear();
                upis_opcije.Visible = false;
                timer1.Start();
                timer2.Stop();
            }

            upis_opcije.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(l.ivica_provera_x(ClientRectangle.Width) == 0)
            {
                b1++;
                label2.Text = b1.ToString();
                l.vrati_se(ClientRectangle.Width/2, ClientRectangle.Height/2);
            }

            if(l.ivica_provera_x(ClientRectangle.Width) == 1)
            {
                i1++;
                label1.Text = i1.ToString();
                l.vrati_se(ClientRectangle.Width/2, ClientRectangle.Height/2);
            }

            if (lopta_druga.ivica_provera_x(ClientRectangle.Width) == 0)
            {
                b1++;
                label2.Text = b1.ToString();
                lopta_druga.vrati_se(ClientRectangle.Width / 2, ClientRectangle.Height / 2);
            }

            if (lopta_druga.ivica_provera_x(ClientRectangle.Width) == 1)
            {
                i1++;
                label1.Text = i1.ToString();
                lopta_druga.vrati_se(ClientRectangle.Width / 2, ClientRectangle.Height / 2);
            }

            if (i1 == 10)
            {
                var poruka = MessageBox.Show("Drugi igrac je pobedio!");
                resetuj_igricu();
            }

            if(b1 == 10)
            {
                var poruka = MessageBox.Show("Prvi igrac je pobedio!");
                resetuj_igricu();
            }

            if(l.ivica_provera_y(ClientRectangle.Height) == true)
            {
                l.ivica_y();
            }

            if (lopta_druga.ivica_provera_y(ClientRectangle.Height) == true)
            {
                lopta_druga.ivica_y();
            }

            if (igrac.sudar_igrac(l))
            {
                l.odbij_se();
                l.ubrzaj_se();
                l.pomeri_se();
            }

            else if (bot.sudar_bot(l))
            {
                l.odbij_se();
                l.ubrzaj_se();
                l.pomeri_se();
            }
            else
            {
                l.pomeri_se();
            }

            if (igrac.sudar_igrac(lopta_druga))
            {
                lopta_druga.odbij_se();
                lopta_druga.ubrzaj_se();
                lopta_druga.pomeri_se();
            }

            else if (bot.sudar_bot(lopta_druga))
            {
                lopta_druga.odbij_se();
                lopta_druga.ubrzaj_se();
                lopta_druga.pomeri_se();
            }
            else
            {
                lopta_druga.pomeri_se();
            }

            if (opcija == 1)
            {
                if (bot.Y + bot.H < l.Y + l.Malo_r)
                {
                    bot.pomeri_se(1);
                }
                else
                {
                    bot.pomeri_se(-1);
                }
            }
            Refresh();
        }
    }
}
