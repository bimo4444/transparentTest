using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace transparentTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Begin();
        }
        private void Begin()
        {
            this.CenterToScreen();
            this.BackColor = SystemColors.Control;       // form background

            ArrowButton[] buttons = new ArrowButtonsFactory().Make();

            foreach (var button in buttons)
                this.Controls.Add(button);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle r = new Rectangle(12, 12, 31, 31);
            e.Graphics.FillRectangle(Brushes.WhiteSmoke, r);    // rectangle background
            e.Graphics.DrawRectangle(
                new Pen(
                    Color.Black, 
                    (float)1.9), 
                r);
        }
    }
}
