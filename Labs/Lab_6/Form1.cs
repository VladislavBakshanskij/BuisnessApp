using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_6 {
    public partial class Form1 : Form {
        private const double END_X = 1.0;
        private const double START_X = -1.0;

        private const double END_Y = 2.0;
        private const double START_Y = -2.0;

        private Font font;
        private SolidBrush solidBrush;

        public Form1() {
            InitializeComponent();
            font = this.Font;
            solidBrush = new SolidBrush(Color.FromArgb(0, 172, 193));
        }

        private void Button3_Click(object sender, EventArgs e) => this.Close();
        private void DrawBtn_Click(object sender, EventArgs e) => pictureBox1.Invalidate();

        private void FondBtn_Click(object sender, EventArgs e) {
            FontDialog fd = new FontDialog();

            if (fd.ShowDialog() == DialogResult.OK) {
                font = fd.Font;
                solidBrush.Color = fd.Color;
            }
        }

        private void DrawFunction(Graphics g, Func<double, double> func) {
            const double SCALE_X = 300.5;
            const double SCALE_Y = 65.5;

            int cx = pictureBox1.Width / 2;
            int cy = pictureBox1.Height / 2;

            decimal countPoints = countPointNumericUpDown.Value;
            double dx = (END_X - START_X) / (double)countPoints;

            float tensition = (float)elasticNumericUpDown.Value;

            g.Clear(Color.White);

            #region Axes
            g.DrawLine(
                Pens.Black,
                new Point(0, cy),
                new Point(pictureBox1.Width, cy)
            );

            g.DrawLine(
                Pens.Black,
                new Point(cx, 0),
                new Point(cx, pictureBox1.Height)
            );
            #endregion

            List<Point> points = new List<Point>();

            for (double i = START_X; i <= END_X; i += dx) {
                double x = i * SCALE_X;
                double y = func(i);

                int xi = (int)(cx + x);
                int yi = (int)(cy - y * SCALE_Y);

                points.Add(new Point(xi, yi));

                g.DrawLine(Pens.Black, xi, cy, xi, cy + 4);
                g.DrawString(Math.Round(i, 2).ToString(), font, solidBrush, xi - 9, cy + 4);
            }

            double dy = (END_Y - START_Y) / (double)countPoints;

            for (double y = START_Y; y <= END_Y; y += dy) {
                int yi = (int)(cy - y * SCALE_Y);

                g.DrawLine(Pens.Black, cx, yi, cx + 4, yi);
                g.DrawString(Math.Round(y, 2).ToString(), font, solidBrush, cx + 4, yi - 3);
            }

            g.DrawCurve(Pens.Red, points.ToArray(), tensition);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e) => DrawFunction(
            e.Graphics,
            (x) => {
                double cos = Math.Pow(Math.Cos(x), 2);
                double numerator = x - 2 / (x - 2);
                double divider = 1 + Math.Pow(1 - x, 2);

                return Math.Abs(cos) * (numerator / divider);
            }
        );
    }
}
