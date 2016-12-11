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
    /// <summary>
    /// hint: the greater side should be even for the best smoothing
    /// </summary>
    class ArrowButton : BaseArrowButton
    {
        #region fields
        Brush enabledBrush, currentBrush;
        public Brush DisabledBrush { get; set; } = Brushes.Silver;
        public Brush OnMouseBrush { get; set; } = Brushes.OrangeRed;
        public Brush EnabledBrush // очень лениво
        {
            get
            {
                return enabledBrush ?? (enabledBrush = currentBrush = Brushes.DodgerBlue);
            }
            set
            {
                enabledBrush = currentBrush = value;
            }
        }
        protected override Brush brush
        {
            get
            {
                return this.Enabled ? currentBrush ?? EnabledBrush : DisabledBrush;
            }
        }
        protected override Pen pen { get; set; } = new Pen(Brushes.Black, (float)1.9);
        #endregion

                #region ctors
        public ArrowButton() : base(Directions.Right, new Size(13, 22)) { }
        public ArrowButton(Directions direction, Brush brush = null, Pen pen = null)
            : base(direction,
                  direction == Directions.Right
                  || direction == Directions.Left
                  ? new Size(13, 22)
                  : new Size(22, 13))
        {
            if (pen != null) this.pen = pen;
            if (brush != null)
                EnabledBrush = brush;
        }
        public ArrowButton(Directions direction, Size size, Brush brush = null, Pen pen = null) : base(direction, size)
        {
            if (pen != null) this.pen = pen;
            if (brush != null)
                EnabledBrush = brush;
        }
        public ArrowButton(Directions direction, bool alternativeColor) : this(direction)
        {
            EnabledBrush = Brushes.MediumTurquoise;
        }
        #endregion

        #region listeners
        protected override void OnMouseEnter(EventArgs e)
        {
            currentBrush = OnMouseBrush;
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            currentBrush = EnabledBrush;
            base.OnMouseLeave(e);
        }
        #endregion
    }
}
