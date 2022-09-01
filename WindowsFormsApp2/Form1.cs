using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        bool md = false;
        Point start = new Point();
        Point current = new Point();
        Button b;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            md = true;
            b = new Button();
            start = new Point(e.X,e.Y);
            b.Location = start;
            b.Text = "Button";
            Controls.Add(b);
        }


        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            md = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(md)
            {
                current = new Point(e.X,e.Y);
                if (e.Y > start.Y && e.X > start.X)
                {
                    b.Location = start;
                    b.Size = new Size(e.X - start.X, e.Y - start.Y);
                }
                else if (e.Y < start.Y && e.X < start.X)
                {
                    b.Location = current;
                    b.Size = new Size(start.X - e.X, start.Y - e.Y);
                }
                else if (e.Y < start.Y && e.X > start.X)
                {
                    b.Location = new Point(start.X,current.Y);
                    b.Size = new Size(current.X - start.X, start.Y - e.Y);
                }
                else if (e.Y > start.Y && e.X < start.X)
                {
                    b.Location = new Point(current.X, start.Y);
                    b.Size = new Size(start.X - e.X, current.Y - start.Y);
                }
            }    
        }
    }
}
