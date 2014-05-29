using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace _3._7._2
{
    public partial class Form1 : Form
    {
        Timer timer;

        public Form1()
        {
            // Włączenie timera 
            timer = new Timer();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = 1000;
            timer.Start();

            // Włączenie podwójnego buforowania 
            this.SetStyle(ControlStyles.UserPaint,true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
        }

        void Timer_Tick(object sender, EventArgs e)
        {            
            this.Refresh();                      // czyszczenie poprzednio rysowanych linii            
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            DrawClock(g);

            // Ustawia srodek
            Point srodek = new Point(0, 0);

            int godz = DateTime.Now.Hour;
            int min = DateTime.Now.Minute;
            int sek = DateTime.Now.Second;

            Pen godzPen = new Pen(Color.Green, 3);
            double godzKat = 2.0 * Math.PI * (godz + min / 60.0) / 12.0;
            // Rysuje wskazówkę godzin
            Point godzWsk = new Point((int)(40 * Math.Sin(godzKat)),
                                        (int)(-40 * Math.Cos(godzKat)));
            g.DrawLine(godzPen, srodek, godzWsk);



            Pen minPen  = new Pen(Color.Blue, 3);
            double minKat = 2.0 * Math.PI * (min + sek / 60.0) / 60.0;
            // Rysuje wskazówke minut
            Point minHand = new Point((int)(70 * Math.Sin(minKat)),
                                       (int)(-70 * Math.Cos(minKat)));
            g.DrawLine(minPen, srodek, minHand);

            Pen secPen  = new Pen(Color.Red, 1);
            double sekKat  = 2.0 * Math.PI * sek / 60.0;
            // Rysuje wskazówkę sekund
            Point secHand = new Point((int)(70 * Math.Sin(sekKat)),
                                       (int)(-70 * Math.Cos(sekKat)));
            g.DrawLine(secPen, srodek, secHand);            
        }

        private void DrawClock(Graphics g)
        {
            SolidBrush solidbrush = new SolidBrush(Color.Black);
            Font textFont = new Font("Verdana", 12F);

            g.DrawString("XII", textFont, solidbrush, 109, 40);
            g.DrawString("XI", textFont, solidbrush, 75, 50);
            g.DrawString("X", textFont, solidbrush, 47, 75);
            g.DrawString("IX", textFont, solidbrush, 43, 110);
            g.DrawString("VIII", textFont, solidbrush, 52, 145);
            g.DrawString("VII", textFont, solidbrush, 75, 170);
            g.DrawString("VI", textFont, solidbrush, 113, 180);
            g.DrawString("V", textFont, solidbrush, 150, 170);
            g.DrawString("IV", textFont, solidbrush, 173, 145);
            g.DrawString("III", textFont, solidbrush, 182, 110);
            g.DrawString("II", textFont, solidbrush, 173, 75);
            g.DrawString("I", textFont, solidbrush, 150, 50);

            g.TranslateTransform(120, 120, MatrixOrder.Append);
        }                
    }
}
