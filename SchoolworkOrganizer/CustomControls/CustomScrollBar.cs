using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentRequestingUtils.CustomControls
{
    public class CustomScrollBar : UserControl
    {
        private int _value = 0;
        private int _maximum = 100;
        private int _minimum = 0;
        private int _thumbSize = 20;

        [Category("Scrollbar"), Description("The color of the scrollbar thumb.")]
        public Color ThumbColor { get; set; } = Color.Gray;

        [Category("Scrollbar"), Description("The color of the scrollbar track.")]
        public Color TrackColor { get; set; } = Color.LightGray;

        [Category("Scrollbar"), Description("The current value of the scrollbar.")]
        public int Value
        {
            get => _value;
            set
            {
                _value = Math.Max(_minimum, Math.Min(value, _maximum));
                Invalidate();
                ValueChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        [Category("Scrollbar"), Description("The maximum value of the scrollbar.")]
        public int Maximum
        {
            get => _maximum;
            set
            {
                _maximum = Math.Max(_minimum, value);
                Invalidate();
            }
        }

        [Category("Scrollbar"), Description("The minimum value of the scrollbar.")]
        public int Minimum
        {
            get => _minimum;
            set
            {
                _minimum = Math.Min(value, _maximum);
                Invalidate();
            }
        }

        [Category("Scrollbar"), Description("The size of the scrollbar thumb.")]
        public int ThumbSize
        {
            get => _thumbSize;
            set
            {
                _thumbSize = Math.Max(10, value); // Ensure a minimum size for the thumb
                Invalidate();
            }
        }

        [Browsable(false)] // Hide from designer
        public float ScrollRatio => (_value - _minimum) / (float)(_maximum - _minimum);

        [Category("Scrollbar"), Description("Occurs when the scrollbar value changes.")]
        public event EventHandler ValueChanged;

        public CustomScrollBar()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);

            Width = 30; // Default width for the scrollbar
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the rounded track
            var trackPath = CreateRoundedRectanglePath(new RectangleF(0, 0, Width, Height), Width / 2);
            using (var trackBrush = new SolidBrush(TrackColor))
            {
                g.FillPath(trackBrush, trackPath);
            }

            float trackHeight = Height - ThumbSize;
            float thumbPosition = trackHeight * (_value - _minimum) / (_maximum - _minimum);

            var thumbRect = new RectangleF(2, thumbPosition + 2, Width - 4, ThumbSize - 4); // Padding for the thumb inside the track
            var thumbPath = CreateRoundedRectanglePath(thumbRect, (Width - 4) / 2);

            using (var thumbBrush = new SolidBrush(ThumbColor))
            {
                g.FillPath(thumbBrush, thumbPath);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            UpdateValueFromPosition(e.Y);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                UpdateValueFromPosition(e.Y);
            }
        }

        private void UpdateValueFromPosition(int mouseY)
        {
            float trackHeight = Height - ThumbSize;
            float ratio = Math.Max(0, Math.Min(1, (float)mouseY / trackHeight));
            Value = (int)(ratio * (_maximum - _minimum)) + _minimum;
        }

        private GraphicsPath CreateRoundedRectanglePath(RectangleF rect, float cornerRadius)
        {
            var path = new GraphicsPath();
            float diameter = cornerRadius * 2;

            // Top-left arc
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            // Top-right arc
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            // Bottom-right arc
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            // Bottom-left arc
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);

            path.CloseFigure();
            return path;
        }
    }


}

