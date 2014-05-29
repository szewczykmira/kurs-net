using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _3._7._3
{
    public partial class Form1 : Form
    {
        int min = 0;
        int max = 100;
        int val = 0;

        Color BarColor = Color.Blue;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush brush = new SolidBrush(BarColor);
            float percent = (float)(val - min) / (float)(max - min);
            Rectangle rect = this.ClientRectangle;

            rect.Width = (int)((float)rect.Width * percent);

            g.FillRectangle(brush, rect);

            Draw3DBorder(g);

            brush.Dispose();
            g.Dispose();

        }

        public int Minimun
        {
            get { return min; }
            set {
                if (value < 0) min = 0;
                if (value > max) min = value;
                if (val < min) val = min;
            }                        
        }

        public int Maximum
        {
            get { return max; }
            set
            {
                if (value < min) min = value;
                max = value;

                if (val > max) val = max;
            }
        }

        public int Value
        {
            get { return val; }
            set {
                int oldValue = value;

                if (value < min) val = min;
                else if (value > max) val = max;
                else val = value;

                float percent;

                Rectangle newValueRect = this.ClientRectangle;
                Rectangle oldValueRect = this.ClientRectangle;

                percent = (float)(val - min) / (float)(max - min);
                newValueRect.Width = (int)((float)newValueRect.Width * percent);

                percent = (float)(val - min) / (float)(max - min);
                oldValueRect.Width = (int)((float)oldValueRect.Width * percent);

                Rectangle updateRect = new Rectangle();

                // znajdz czesc okna ktora musi zostac zaktualizowana
                if (newValueRect.Width > oldValueRect.Width)
                {
                    updateRect.X = oldValueRect.Size.Width;
                    updateRect.Width = newValueRect.Width - oldValueRect.Width;
                }
                else
                {
                    updateRect.X = newValueRect.Size.Width;
                    updateRect.Width = oldValueRect.Width - newValueRect.Width;
                }

                updateRect.Height = this.Height;

                this.Invalidate(updateRect);
            
            }
        }


        public Color ProgressBarColor
        {
            get { return BarColor; }
            set
            {
                BarColor = value;
                this.Invalidate();
            }
        }

        private void Draw3DBorder(Graphics g)
        {
            int PenWidth = (int)Pens.White.Width;

            g.DrawLine(Pens.DarkGray,
                new Point(this.ClientRectangle.Left, this.ClientRectangle.Top),
                new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Top));
            g.DrawLine(Pens.DarkGray,
                new Point(this.ClientRectangle.Left, this.ClientRectangle.Top),
                new Point(this.ClientRectangle.Left, this.ClientRectangle.Height - PenWidth));
            g.DrawLine(Pens.White,
                new Point(this.ClientRectangle.Left, this.ClientRectangle.Height - PenWidth),
                new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Height - PenWidth));
            g.DrawLine(Pens.White,
                new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Top),
                new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Height - PenWidth));
        } 

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
