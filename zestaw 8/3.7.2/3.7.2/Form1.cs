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
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer
                          , true);

            InitializeComponent();
        }

        void Timer_Tick(object sender, EventArgs e)
        {            
            this.Refresh();                      // czyszczenie poprzednio rysowanych linii            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            DrawClock(g);
            
            int godz = DateTime.Now.Hour;
            int min = DateTime.Now.Minute;
            int sek = DateTime.Now.Second;

            // Tworzy pedzle
            Pen godzPen = new Pen(Color.White, 3);
            Pen minPen  = new Pen(Color.Gray, 3);
            Pen secPen  = new Pen(Color.Red, 1);

            // Tworzy kąty
            double sekKat  = 2.0 * Math.PI * sek / 60.0;
            double minKat  = 2.0 * Math.PI * (min + sek / 60.0) / 60.0;
            double godzKat = 2.0 * Math.PI * (godz + min / 60.0) / 12.0;

            // Ustawia srodek
            Point srodek = new Point(0, 0);

            // Rysuje wskazówkę godzin
            Point godzWsk = new Point((int)(40 * Math.Sin(godzKat)),
                                        (int)(-40 * Math.Cos(godzKat)));
            g.DrawLine(godzPen, srodek, godzWsk);

            // Rysuje wskazówke minut
            Point minHand = new Point((int)(70 * Math.Sin(minKat)),
                                       (int)(-70 * Math.Cos(minKat)));
            g.DrawLine(minPen, srodek, minHand);

            // Rysuje wskazówkę sekund
            Point secHand = new Point((int)(70 * Math.Sin(sekKat)),
                                       (int)(-70 * Math.Cos(sekKat)));
            g.DrawLine(secPen, srodek, secHand);            
           
        }

        private void DrawClock(Graphics g)
        {
            Rectangle rec = new Rectangle(2, 20, 250, 250);
            LinearGradientBrush linearbrush = new LinearGradientBrush(rec, Color.Brown, Color.Green, 50);
            g.FillEllipse(linearbrush, 20, 20, 200, 200);

            SolidBrush solidbrush = new SolidBrush(Color.White);
            Font textFont = new Font("Times New Roman Bold", 12F);

            g.DrawString("12", textFont, solidbrush, 109, 40);
            g.DrawString("11", textFont, solidbrush, 75, 50);
            g.DrawString("10", textFont, solidbrush, 47, 75);
            g.DrawString("9", textFont, solidbrush, 43, 110);
            g.DrawString("8", textFont, solidbrush, 52, 145);
            g.DrawString("7", textFont, solidbrush, 75, 170);
            g.DrawString("6", textFont, solidbrush, 113, 180);
            g.DrawString("5", textFont, solidbrush, 150, 170);
            g.DrawString("4", textFont, solidbrush, 173, 145);
            g.DrawString("3", textFont, solidbrush, 182, 110);
            g.DrawString("2", textFont, solidbrush, 173, 75);
            g.DrawString("1", textFont, solidbrush, 150, 50);

            g.TranslateTransform(120, 120, MatrixOrder.Append);
        }                

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
