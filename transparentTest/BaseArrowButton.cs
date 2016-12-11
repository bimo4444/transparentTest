using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace transparentTest
{
    enum Directions
    {
        Right,
        Down,
        Left,
        Up
    }
    abstract class BaseArrowButton : Button
    {
        #region fields
        protected Point[] points;
        abstract protected Pen pen { get; set; }
        abstract protected Brush brush { get; }
        protected Directions direction { get; set; }
        #endregion

        #region ctor
        public BaseArrowButton(Directions direction, Size size)
        {
            this.direction = direction;
            this.Size = size;
        }
        #endregion

        #region listeners
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Transparent);
            e.Graphics.FillPolygon(
                brush,
                points);
            e.Graphics.DrawPolygon(
                pen,
                points);
        }
        protected override void OnResize(EventArgs e)
        {
            GenPoints();
            SetRegion();
        }
        #endregion

        #region private
        private Point[] GenPoints()
        {
            switch (direction)
            {
                case Directions.Right:
                    return (points = new Point[]
                        {
                            new Point(2, 2),
                            new Point(this.Width - 2, this.Height / 2),
                            new Point(2, this.Height - 2)
                        });

                case Directions.Left:
                    return (points = new Point[]
                        {
                            new Point(this.Width - 2, 2),
                            new Point(this.Width - 2, this.Height - 2),
                            new Point(2, this.Height / 2)
                        });

                case Directions.Down:
                    return (points = new Point[]
                        {
                            new Point(2, 2),
                            new Point(this.Width - 2, 2),
                            new Point(this.Width / 2, this.Height - 2)
                        });

                case Directions.Up:
                    return (points = new Point[]
                        {
                            new Point(this.Width / 2, 2),
                            new Point(this.Width - 2, this.Height - 2),
                            new Point(2, this.Height - 2)
                        });

                default:
                    return null;
            }
        }
        private void SetRegion()
        {
            GraphicsPath formPath = new GraphicsPath();
            formPath.AddPolygon(points);
            this.Region = new Region(formPath);
        }
        #endregion
    }
}
